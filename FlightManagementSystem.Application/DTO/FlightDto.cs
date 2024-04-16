using FlightManagementSystem.Domain;

namespace FlightManagementSystem.Application.DTO
{
    public record FlightDto (int Id, string FlightNumber, DateTime DateDeparture, string PlaceDeparture, string PlaceArrival, AircraftType AircraftType);
}
