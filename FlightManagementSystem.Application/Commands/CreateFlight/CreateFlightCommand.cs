using FlightManagementSystem.Domain;
using MediatR;

namespace FlightManagementSystem.Application.Commands.CreateFlight
{
    public record CreateFlightCommand(string FlightNumber, DateTime DateDeparture, string PlaceDeparture, string PlaceArrival, AircraftType AircraftType) : IRequest<int>;
}
