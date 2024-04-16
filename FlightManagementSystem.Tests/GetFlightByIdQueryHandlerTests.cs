using FlightManagementSystem.Application.Exceptions;
using FlightManagementSystem.Application.Queries.GetFlightById;
using FlightManagementSystem.Domain;
using FlightManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace FlightManagementSystem.Tests
{
    public class GetFlightByIdQueryHandlerTests
    {
        private readonly DbContextOptions<FlightsDbContext> _options;
        public GetFlightByIdQueryHandlerTests()
        {
            _options = new DbContextOptionsBuilder<FlightsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetFlightTestDb")
                .Options;

            using var context = new FlightsDbContext(_options);
            context.Flights.Add(new Flight { Id = 1, FlightNumber = "FL123" });
            context.SaveChanges();
        }

        [Fact]
        public async Task Handle_ValidId_ReturnsFlight()
        {
            using var context = new FlightsDbContext(_options);
            var handler = new GetFlightByIdQueryHandler(context);
            var query = new GetFlightByIdQuery (1);

            // Act
            var flight = await handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(flight);
            Assert.Equal("FL123", flight.FlightNumber);
        }

        [Fact]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            using var context = new FlightsDbContext(_options);
            context.Database.EnsureDeleted(); // Clear the database before adding new entities

            var handler = new GetFlightByIdQueryHandler(context);
            var query = new GetFlightByIdQuery(999);  // Intentionally non-existent ID

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(query, new CancellationToken()));

            Assert.Contains("999", exception.Message);  // Checks if the error message contains the flight ID
        }

        public void Dispose()
        {
            using var context = new FlightsDbContext(_options);
            context.Database.EnsureDeleted(); // Ensure the database is deleted after all tests
        }
    }
}
