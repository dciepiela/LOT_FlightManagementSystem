using FlightManagementSystem.Application.DTO;
using MediatR;

namespace FlightManagementSystem.Application.Queries.GetFlightById
{
    public record GetFlightByIdQuery(int Id) : IRequest<FlightDto>;

}
