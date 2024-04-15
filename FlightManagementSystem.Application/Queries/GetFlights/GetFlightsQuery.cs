using FlightManagementSystem.Application.DTO;
using MediatR;

namespace FlightManagementSystem.Application.Queries.GetFlights
{
    public record GetFlightsQuery() : IRequest<List<FlightDto>>;
}
