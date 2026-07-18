namespace Logistics.Domain.Tests;
using FluentAssertions;
using Logistics.Domain.Entities;
using Logistics.Domain.Services;
using Logistics.Domain.ValueObjects;

public class SimpleLoadOptimizerTests
{
    [Fact]
    public void Optimize_ShouldPlaceSinglePalletAtOrigin()
    {
        var truck = new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                2450,
                2700),
            24000);

        var pallet = new Pallet(
            Guid.NewGuid(),
            new Dimensions(
                1200,
                800,
                1500),
            500);

        var optimizer = new SimpleLoadOptimizer();

        var result = optimizer.Optimize(
            truck,
            [pallet]);

        result.Placements.Should().HaveCount(1);

        var placement = result.Placements.Single();

        placement.Position.X.Should().Be(0);
        placement.Position.Y.Should().Be(0);
    }

    [Fact]
    public void Optimize_ShouldPlacePalletsNextToEachOther()
    {
        var truck = new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                2450,
                2700),
            24000);

        var pallet1 = new Pallet(
            Guid.NewGuid(),
            new Dimensions(
                1200,
                800,
                1500),
            500);

        var pallet2 = new Pallet(
            Guid.NewGuid(),
            new Dimensions(
                1200,
                800,
                1500),
            500);

        var optimizer = new SimpleLoadOptimizer();

        var result = optimizer.Optimize(
            truck,
            [pallet1, pallet2]);

        result.Placements.ElementAt(0)
            .Position.X.Should().Be(0);

        result.Placements.ElementAt(1)
            .Position.X.Should().Be(1200);
    }


    [Fact]
    public void Optimize_ShouldThrow_WhenPalletsExceedTruckLength()
    {
        var truck = new Truck(
            Guid.NewGuid(),
            new Dimensions(
                2000,
                2450,
                2700),
            24000);

        var pallet1 = new Pallet(
            Guid.NewGuid(),
            new Dimensions(
                1200,
                800,
                1500),
            500);

        var pallet2 = new Pallet(
            Guid.NewGuid(),
            new Dimensions(
                1200,
                800,
                1500),
            500);

        var optimizer = new SimpleLoadOptimizer();

        Action action = () =>
            optimizer.Optimize(
                truck,
                [pallet1, pallet2]);

        action.Should()
            .Throw<InvalidOperationException>();
    }

}