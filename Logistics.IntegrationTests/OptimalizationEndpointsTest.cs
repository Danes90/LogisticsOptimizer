namespace Logistics.IntegrationTests;

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
public class OptimalizationEndpointsTest
{

    [Fact]
    public async Task Optimize_ShouldReturnLoadPlan()
    {
        await using var factory =
            new WebApplicationFactory<Program>();

        var client = factory.CreateClient();

        await client.PostAsJsonAsync(
            "/api/trucks",
            new
            {
                Length = 13600,
                Width = 2450,
                Height = 2700,
                MaxWeight = 24000
            });

        await client.PostAsJsonAsync(
            "/api/pallets",
            new
            {
                Length = 1200,
                Width = 800,
                Height = 1500,
                Weight = 500
            });

        var trucks =
            await client.GetFromJsonAsync<List<TruckResponse>>(
                "/api/trucks");

        var pallets =
            await client.GetFromJsonAsync<List<PalletResponse>>(
                "/api/pallets");

        var response =
            await client.PostAsJsonAsync(
                "/api/optimization",
                new
                {
                    TruckId = trucks![0].Id,
                    PalletIds = new[]
                    {
                    pallets![0].Id
                    }
                });

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var plan =
            await response.Content
                .ReadFromJsonAsync<OptimizationResponse>();

        plan.Should().NotBeNull();
        plan!.Placements.Should().HaveCount(1);
    }

    [Fact]
    public async Task Optimize_InvalidTruck_ShouldReturn404()
    {
        await using var factory =
            new WebApplicationFactory<Program>();

        var client = factory.CreateClient();

        var response =
            await client.PostAsJsonAsync(
                "/api/optimization",
                new
                {
                    TruckId = Guid.NewGuid(),
                    PalletIds = Array.Empty<Guid>()
                });

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

}

public sealed class OptimizationResponse
{
    public int TotalWeight { get; set; }
    public bool IsOverWeight { get; set; }
    public List<PlacementResponse> Placements { get; set; } = [];
}

public sealed class PlacementResponse
{
    public Guid PalletId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}
