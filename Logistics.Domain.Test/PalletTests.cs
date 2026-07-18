namespace Logistics.Domain.Tests;
using FluentAssertions;
using Logistics.Domain.Entities;
using Logistics.Domain.ValueObjects;



public class PalletTests
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
     * test pallet creation with valid values
     */
    [Fact]
    public void CreatePallet_WithValidValues_ShouldSucceed()
    {
        var pallet = new Pallet(
            Guid.NewGuid(),
            new Dimensions(1200, 800, 1500),
            500);

        pallet.Weight.Should().Be(500);
    }


    /**
     * test pallet creation with invalid weight
     */
    [Fact]
    public void CreatePallet_WithInvalidWeight_ShouldThrow()
    {
            Action action = () =>
                new Pallet(
                    Guid.NewGuid(),
                    new Dimensions(
                        1200,
                        800,
                        1500),
                    0);

            action.Should()
                .Throw<ArgumentOutOfRangeException>();
     }

}