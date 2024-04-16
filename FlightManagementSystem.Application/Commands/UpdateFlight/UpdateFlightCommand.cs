using FlightManagementSystem.Domain;
using MediatR;

namespace FlightManagementSystem.Application.Commands.UpdateFlight
{
    public record UpdateFlightCommand(int Id, string FlightNumber, DateTime DateDeparture, string PlaceDeparture, string PlaceArrival, AircraftType AircraftType) : IRequest<Unit>;
}
