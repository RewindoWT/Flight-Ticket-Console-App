// Airport.cs


namespace GALA_FLY_Ticket_App.Models
{
    public static class Airport
    {
        public static Location IstanbulAirport => new Location { Country = "Turkey", City = "Istanbul", AirportCode = "IST", IsActive = true };
        public static Location NewYorkAirport => new Location { Country = "USA", City = "New York", AirportCode = "JFK", IsActive = true };
        public static Location ParisAirport => new Location { Country = "France", City = "Paris", AirportCode = "CDG", IsActive = true };
        public static Location TokyoAirport => new Location { Country = "Japan", City = "Tokyo", AirportCode = "NRT", IsActive = true };
    }
}