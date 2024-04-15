using FlightManagementSystem.Application.DTO;
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
                throw new Exception();
            }

            return flight.Adapt<FlightDto>();
        }
    }
}
