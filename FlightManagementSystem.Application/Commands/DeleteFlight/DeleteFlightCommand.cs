using MediatR;

namespace FlightManagementSystem.Application.Commands.DeleteFlight
{
    public record DeleteFlightCommand(int Id) :IRequest<Unit>;
}
