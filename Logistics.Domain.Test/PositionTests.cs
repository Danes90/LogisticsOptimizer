namespace Logistics.Domain.Test;
using FluentAssertions;
using Logistics.Domain.ValueObjects;

public class PositionTests
{

    /**
     * test setup
     */
    [Fact]
    public void CreatePosition_WithValidValues_ShouldSucceed()
    {
        var position = new Position(
            100,
            200);

        position.X.Should().Be(100);
        position.Y.Should().Be(200);
    }
}
