// FlightReservationSystem.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GALA_FLY_Ticket_App.Models;
    
namespace GALA_FLY_Ticket_App.Services
{

    public class FlightReservationSystem
    {
        private List<Flight> flights;

        public FlightReservationSystem()
        {
            flights = new List<Flight>
            {
                 new Flight
            {
                FlightNumber = "GA101",
                From = new Location { Country = "Turkey", City = "Istanbul", AirportCode = "IST", IsActive = true },
                To = new Location { Country = "USA", City = "New York", AirportCode = "JFK", IsActive = true },
                DepartureTime = DateTime.Now.AddHours(2),
                ArrivalTime = DateTime.Now.AddHours(10),
                Cost = 500,
                AircraftType = "Boeing 777",
                TotalSeats = 24
            },
            new Flight
            {
                FlightNumber = "GA102",
                From = new Location { Country = "USA", City = "New York", AirportCode = "JFK", IsActive = true },
                To = new Location { Country = "France", City = "Paris", AirportCode = "CDG", IsActive = true },
                DepartureTime = DateTime.Now.AddHours(3),
                ArrivalTime = DateTime.Now.AddHours(11),
                Cost = 600,
                AircraftType = "Airbus A380",
                TotalSeats = 30
            },
            new Flight
            {
                FlightNumber = "GA103",
                From = new Location { Country = "France", City = "Paris", AirportCode = "CDG", IsActive = true },
                To = new Location { Country = "Japan", City = "Tokyo", AirportCode = "NRT", IsActive = true },
                DepartureTime = DateTime.Now.AddHours(4),
                ArrivalTime = DateTime.Now.AddHours(12),
                Cost = 700,
                AircraftType = "Boeing 747",
                TotalSeats = 36
            },
            };
        }

        public void DisplayAllFlights()
        {
            Console.WriteLine("Tum Ucuslar\n");

            foreach (var flight in flights)
            {
                flight.DisplayFlightDetails();
                Console.WriteLine("------------------------------");
            }
        }

        public void BookFlight()
        {
            Console.WriteLine("Ucus ayarlama\n");

            Console.Write("Ucus numarasini giriniz Ornek(GA103): ");
            string flightNumber = Console.ReadLine();

            var selectedFlight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

            if (selectedFlight != null)
            {
                selectedFlight.DisplayFlightDetails();
                selectedFlight.DisplayAvailableSeats();

                Console.Write("Rezervasyon yapmak istediginiz koltugu seciniz (Ornek: A1): ");
                string selectedSeat = Console.ReadLine().ToUpper();

                if (selectedFlight.BookSeat(selectedSeat))
                {
                    // Reservation successful
                }
            }
            else
            {
                Console.WriteLine("Gecersiz ucus numarasi. Lutfen tekrar deneyin.");
            }
        }

        public void DisplayReservations()
        {
            try
            {
                string dosyaYolu = Path.Combine("Data", "reservations.txt");

                if (File.Exists(dosyaYolu))
                {
                    Console.WriteLine("Rezervasyonlar\n");

                    string[] allLines = System.IO.File.ReadAllLines(dosyaYolu);

                    foreach (var line in allLines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Hata: Dosya bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }


        public bool ValidateSeatInput(string input)
        {
            if (input.Length != 2)
            {
                return false;
            }

            char row = input[0];
            int seatNumber;

            if (!char.IsLetter(row) || !int.TryParse(input[1].ToString(), out seatNumber))
            {
                return false;
            }

            if (row < 'A' || row > 'I' || seatNumber < 1 || seatNumber > 4)
            {
                return false;
            }

            return true;
        }
    }
}
