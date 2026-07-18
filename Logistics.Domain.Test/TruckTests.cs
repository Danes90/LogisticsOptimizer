namespace Logistics.Domain.Tests;
using FluentAssertions;
using Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;

public class TruckTests
{
    /**
     * test setup
     */
    [Fact]
    public void True_Should_Be_True()
    {
        true.Should().BeTrue();
    }

    /**
     * test truck creation with valid dimensions
     */
    [Fact]
    public void CreateTruck_WithValidDimensions_ShouldSucceed() {


        var truck = new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                2450,
                2700),
            24000);

        truck.Dimensions.Length.Should().Be(13600);
    }

    /**
     * test truck creation with invalid length
     */
    [Fact]
    public void CreateTruck_WithInvalidLength_ShouldThrow()
    {
        Action action = () =>
            new Truck(
            Guid.NewGuid(),
            new Dimensions(
                0,
                2450,
                2700),
            24000);

        action.Should()
            .Throw<ArgumentOutOfRangeException>();
    }

    /**
     * test truck creation with invalid width
     */
    [Fact]
    public void CreateTruck_WithInvalidWidth_ShouldThrow()
    {
        Action action = () =>
            new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                0,
                2700),
            24000);
        action.Should()
            .Throw<ArgumentOutOfRangeException>();
    }

    /**
     * test truck creation with invalid height
     */
    [Fact]
    public void CreateTruck_WithInvalidHeight_ShouldThrow()
    {
        Action action = () =>
           new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                2450,
                0),
            24000);
        action.Should()
            .Throw<ArgumentOutOfRangeException>();
    }

    /**
     * test truck creation with invalid max weight
     */
    [Fact]
    public void CreateTruck_WithInvalidMaxWeight_ShouldThrow()
    {
        Action action = () =>
           new Truck(
            Guid.NewGuid(),
            new Dimensions(
                13600,
                2450,
                2700),
            0);
        action.Should()
            .Throw<ArgumentOutOfRangeException>();
    }
}