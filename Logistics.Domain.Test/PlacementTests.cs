namespace Logistics.Domain.Tests;
using FluentAssertions;
using Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;

public class PlacementTests
{
    [Fact]
    public void CreatePlacement_WithValidValues_ShouldSucceed()
    {
        var pallet = new Pallet(
            Guid.NewGuid(),
            new Dimensions(1200, 800, 1500),
            500);

        var position = new Position(
            0,
            0);

        var placement = new Placement(
            pallet,
            position);

        placement.Pallet.Should().Be(pallet);
        placement.Position.Should().Be(position);
    }


    [Fact]
    public void CreatePlacement_WithNullPallet_ShouldThrow()
    {
        Action action = () =>
            new Placement(
                null!,
                new Position(
                    0,
                    0));

        action.Should()
            .Throw<ArgumentNullException>();
    }

    [Fact]
    public void CreatePlacement_WithNullPosition_ShouldThrow()
    {
        var pallet = new Pallet(
            Guid.NewGuid(),
            new Dimensions(
                1200,
                800,
                1500),
            500);

        Action action = () =>
            new Placement(
                pallet,
                null!);

        action.Should()
            .Throw<ArgumentNullException>();
    }
}