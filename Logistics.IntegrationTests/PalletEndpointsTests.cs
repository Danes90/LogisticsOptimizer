

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Logistics.IntegrationTests;

public class PalletEndpointsTests
{
    [Fact]
    public async Task CreatePallet_ShouldReturnSuccess()
    {
        await using var factory =
            new WebApplicationFactory<Program>();

        var client = factory.CreateClient();

        var response =
            await client.PostAsJsonAsync(
                "/api/pallets",
                new
                {
                    Length = 1200,
                    Width = 800,
                    Height = 1500,
                    Weight = 500
                });

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetPallets_ShouldReturnCreatedPallet()
    {
        await using var factory =
            new WebApplicationFactory<Program>();

        var client = factory.CreateClient();

        await client.PostAsJsonAsync(
            "/api/pallets",
            new
            {
                Length = 1200,
                Width = 800,
                Height = 1500,
                Weight = 500
            });

        var response =
            await client.GetAsync("/api/pallets");

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var pallets =
            await response.Content
                .ReadFromJsonAsync<List<PalletResponse>>();

        pallets.Should().NotBeEmpty();
    }
}

public sealed class PalletResponse
{
    public Guid Id { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public int Weight { get; set; }
}