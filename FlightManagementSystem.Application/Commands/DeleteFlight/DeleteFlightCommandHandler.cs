﻿using FlightManagementSystem.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Application.Commands.DeleteFlight
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, Unit>
    {
        private readonly FlightsDbContext _context;

        public DeleteFlightCommandHandler(FlightsDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flightToDelete =await _context.Flights
                .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (flightToDelete is null)
            {
                throw new Exception();
            }

            _context.Flights.Remove(flightToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
