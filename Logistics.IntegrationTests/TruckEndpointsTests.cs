using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Logistics.IntegrationTests;

public class TruckEndpointsTests
{
    [Fact]
    public async Task CreateTruck_ShouldReturnSuccess()
    {
        await using var factory =
            new WebApplicationFactory<Program>();

        var client = factory.CreateClient();

        var response =
            await client.PostAsJsonAsync(
                "/api/trucks",
                new
                {
                    Length = 13600,
                    Width = 2450,
                    Height = 2700,
                    MaxWeight = 24000
                });

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetTrucks_ShouldReturnCreatedTruck()
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

        var response =
            await client.GetAsync("/api/trucks");

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var trucks =
            await response.Content
                .ReadFromJsonAsync<List<TruckResponse>>();

        trucks.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CreateTruck_InvalidRequest_ShouldReturn400()
    {
        await using var factory =
            new WebApplicationFactory<Program>();

        var client = factory.CreateClient();

        var response =
            await client.PostAsJsonAsync(
                "/api/trucks",
                new
                {
                    Length = -1,
                    Width = 0,
                    Height = 0,
                    MaxWeight = 0
                });

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }
}


public sealed class TruckResponse
{
    public Guid Id { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int MaxWeight { get; set; }
}
