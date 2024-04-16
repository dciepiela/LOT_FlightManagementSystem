using FlightManagementSystem.Domain;
using FlightManagementSystem.Persistence;
using FlightManagementSystem.Application.Commands.CreateFlight;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Tests
{
    public class CreateFlightCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_FlightIsCreated()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FlightsDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new FlightsDbContext(options);
            var handler = new CreateFlightCommandHandler(context);

            var command = new CreateFlightCommand(
                "FL123",
                DateTime.UtcNow.AddDays(1),
                "CityA",
                "CityB",
                AircraftType.Boeing
            );

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(1, context.Flights.Count());
            Assert.Contains(context.Flights, f => f.FlightNumber == "FL123");
        }
    }
}
    
