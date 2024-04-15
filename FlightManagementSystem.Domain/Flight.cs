namespace FlightManagementSystem.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DateDeparture {  get; set; }
        public string PlaceDeparture { get; set; }
        public string PlaceArrival { get; set; }
        public AircraftType AircraftType { get; set; }
    }
}
