namespace Logistics.Domain.Test;
using FluentAssertions;
using Logistics.Domain.ValueObjects;

public class DimensionsTests
{

    /**
     * test setup
     */
    [Fact]
    public void CreateDimensions_WithValidValues_ShouldSucceed()
    {
        var dimensions = new Dimensions(
            100,
            200,
            300);

        dimensions.Length.Should().Be(100);
        dimensions.Width.Should().Be(200);
        dimensions.Height.Should().Be(300);
    }

    /**
     * test dimensions creation with invalid length
     */
    [Fact]
    public void CreateDimensions_WithInvalidLength_ShouldThrow()
    {
        Action action = () =>
            new Dimensions(
                0,
                200,
                300);

        action.Should()
            .Throw<ArgumentOutOfRangeException>();
    }


    /**
     * test dimensions creation with invalid width
     */
    [Fact]
    public void CreateDimensions_WithInvalidWidth_ShouldThrow()
    {
        Action action = () =>
            new Dimensions(
                100,
                0,
                300);

        action.Should()
            .Throw<ArgumentOutOfRangeException>();
    }

    /**
     * test dimensions creation with invalid height
     */
    [Fact]
    public void CreateDimensions_WithInvalidHeight_ShouldThrow()
    {
        Action action = () =>
            new Dimensions(
                100,
                200,
                0);

        action.Should()
            .Throw<ArgumentOutOfRangeException>();
    }

}
