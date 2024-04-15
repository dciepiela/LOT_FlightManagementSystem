using FlightManagementSystem.Domain;
using FlightManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Tests.Flights.Queries
{
    [TestFixture]
    public class FlightsDbContextTests
    {
        private DbContextOptions<FlightsDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<FlightsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public void AddFlight_SaveChanges_Success()
        {
            // Arrange
            using (var context = new FlightsDbContext(_options))
            {
                var flight = new Flight
                {
                    FlightNumber = "ABC123",
                    DateDeparture = DateTime.UtcNow,
                    PlaceDeparture = "New York",
                    PlaceArrival = "London",
                    AircraftType = AircraftType.Boeing // Assuming this is the desired aircraft type
                };

                // Act
                context.Flights.Add(flight);
                context.SaveChanges();
            }

            // Assert
            using (var context = new FlightsDbContext(_options))
            {
                var savedFlight = context.Flights.FirstOrDefault();
                Assert.IsNotNull(savedFlight);
                Assert.AreEqual("ABC123", savedFlight.FlightNumber);
                Assert.AreEqual("New York", savedFlight.PlaceDeparture);
                Assert.AreEqual("London", savedFlight.PlaceArrival);
                // Add more assertions as needed
            }
        }
    }
}
