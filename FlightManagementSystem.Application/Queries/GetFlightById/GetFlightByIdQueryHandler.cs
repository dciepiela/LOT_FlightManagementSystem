using FlightManagementSystem.Application.DTO;
using FlightManagementSystem.Application.Exceptions;
using FlightManagementSystem.Domain;
using FlightManagementSystem.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Application.Queries.GetFlightById
{
    public class GetFlightByIdQueryHandler : IRequestHandler<GetFlightByIdQuery, FlightDto>
    {
        private readonly FlightsDbContext _context;

        public GetFlightByIdQueryHandler(FlightsDbContext context)
        {
            _context = context;
        }

        public async Task<FlightDto> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var flight = await _context.Flights
                .FirstOrDefaultAsync(f => f.Id == request.Id,cancellationToken);

            if(flight == null)
            {
                throw new NotFoundException($"{nameof(Flight)} z {nameof(Flight.Id)}: {request.Id}" + $"nie został znaleziony w bazie danych");
            }

            return flight.Adapt<FlightDto>();
        }
    }
}
