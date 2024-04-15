using FlightManagementSystem.Domain;

namespace FlightManagementSystem.Application.DTO
{
    public record UpdateFlightDto(string FlightNumber, DateTime DateDeparture, string PlaceDeparture, string PlaceArrival, AircraftType AircraftType);
}
