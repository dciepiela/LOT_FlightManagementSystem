using FlightManagementSystem.Application.Exceptions;
using FlightManagementSystem.Domain;
using FlightManagementSystem.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Application.Commands.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, Unit>
    {
        private readonly FlightsDbContext _context;

        public UpdateFlightCommandHandler(FlightsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flightToUpdate = await _context.Flights.FirstOrDefaultAsync(f => f.Id == request.Id,cancellationToken);

            if(flightToUpdate == null)
            {
                throw new NotFoundException($"{nameof(Flight)} z {nameof(Flight.Id)}: {request.Id}" + $"nie został znaleziony w bazie danych");
            }

            flightToUpdate.FlightNumber = request.FlightNumber;
            flightToUpdate.DateDeparture = request.DateDeparture;
            flightToUpdate.PlaceDeparture = request.PlaceDeparture;
            flightToUpdate.PlaceArrival = request.PlaceArrival;
            flightToUpdate.AircraftType = request.AircraftType;


            _context.Flights.Add(flightToUpdate);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
