namespace Logistics.Domain.Test;
using FluentAssertions;
using Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;
public class LoadPlanTests
{
    
    [Fact]
    public void CreateLoadPlan_WithValidValues_ShouldSucceed()
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

        var placement = new Placement(
            pallet,
            new Position(
                0,
                0));

        var loadPlan = new LoadPlan(
            truck,
            new List<Placement>
            {
                placement
            });

        loadPlan.Truck.Should().Be(truck);
        loadPlan.Placements.Should().HaveCount(1);
    }


    [Fact]
    public void CreateLoadPlan_WithNullTruck_ShouldThrow()
    {
        Action action = () =>
            new LoadPlan(
                null!,
                new List<Placement>());

        action.Should()
            .Throw<ArgumentNullException>();
    }

    [Fact]
    public void CreateLoadPlan_WithNullPlacements_ShouldThrow()
    {
        var truck = new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                2450,
                2700),
            24000);

        Action action = () =>
            new LoadPlan(
                truck,
                null!);

        action.Should()
            .Throw<ArgumentNullException>();
    }

    [Fact]
    public void GetTotalWeight_ShouldReturnSumOfPlacedPallets()
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
            700);

        var loadPlan = new LoadPlan(
            truck,
            new List<Placement>
            {
            new(
                pallet1,
                new Position(0,0)),
            new(
                pallet2,
                new Position(1200,0))
            });

        loadPlan.TotalWeight.Should().Be(1200);
    }

    [Fact]
    public void IsOverWeight_ShouldReturnTrue_WhenWeightExceedsTruckCapacity()
    {
        var truck = new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                2450,
                2700),
            1000);

        var loadPlan = new LoadPlan(
            truck,
            new List<Placement>
            {
            new(
                new Pallet(
                    Guid.NewGuid(),
                    new Dimensions(
                        1200,
                        800,
                        1500),
                    1200),
                new Position(
                    0,
                    0))
            });

        loadPlan.IsOverWeight.Should().BeTrue();
    }
}