using FlightManagementSystem.Application.DTO;
using FlightManagementSystem.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Application.Queries.GetFlights
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, List<FlightDto>>
    {
        private readonly FlightsDbContext _context;

        public GetFlightsQueryHandler(FlightsDbContext context)
        {
            _context = context;
        }

        public async Task<List<FlightDto>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _context.Flights.ToListAsync();

            return flights.Adapt<List<FlightDto>>();
        }
    }
}
