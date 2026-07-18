namespace Logistics.Application.Tests;

using FluentAssertions;
using Logistics.Application.Commands.CreateTruck;
using Logistics.Application.Interfaces;
using Moq;
using System.Timers;



public class CreateTruckHandlerTests
{
    [Fact]
    public async Task Handle_Should_SaveTruck()
    {
        var repository =
            new Mock<ITruckRepository>();

        var handler =
            new CreateTruckHandler(
                repository.Object);

        var command =
            new CreateTruckCommand(
                13600,
                2450,
                2700,
                24000);

        await handler.Handle(
            command,
            CancellationToken.None);

        repository.Verify(
            x => x.AddAsync(
                It.IsAny<Logistics.Domain.Entities.Truck>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}