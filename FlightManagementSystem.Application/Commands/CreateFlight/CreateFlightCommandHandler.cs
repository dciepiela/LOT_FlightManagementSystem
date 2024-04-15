using FlightManagementSystem.Domain;
using FlightManagementSystem.Persistence;
using MediatR;

namespace FlightManagementSystem.Application.Commands.CreateFlight
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, int>
    {
        private readonly FlightsDbContext _context;

        public CreateFlightCommandHandler(FlightsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Flight
            {
                FlightNumber = request.FlightNumber,
                DateDeparture = request.DateDeparture,
                PlaceDeparture = request.PlaceDeparture,
                PlaceArrival = request.PlaceArrival,
                AircraftType = request.AircraftType
            };

            await _context.Flights.AddAsync(flight,cancellationToken);
            var id = await _context.SaveChangesAsync(cancellationToken);

            return id;
        }
    }
}
