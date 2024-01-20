// Flight.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GALA_FLY_Ticket_App.Models
{

    public class Flight
    {
        public string FlightNumber { get; set; }
        public Location From { get; set; }
        public Location To { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Cost { get; set; }
        public string AircraftType { get; set; }
        public int TotalSeats { get; set; }
        public List<string> BookedSeats { get; set; } = new List<string>();
        public string TicketNumber { get; set; }
        public Passenger Passenger { get; set; }






        public void DisplayFlightDetails()
        {
            Console.WriteLine($"Flight: {FlightNumber}");
            Console.WriteLine($"From: {From.City}, {From.Country}");
            Console.WriteLine($"To: {To.City}, {To.Country}");
            Console.WriteLine($"Departure Time: {DepartureTime}");
            Console.WriteLine($"Arrival Time: {ArrivalTime}");
            Console.WriteLine($"Cost: {Cost:C}");
            Console.WriteLine($"Aircraft Type: {AircraftType}");
            Console.WriteLine($"Total Seats: {TotalSeats}");
        }

        public void DisplayAvailableSeats()
        {
            Console.WriteLine("Available Seats:");
            for (char row = 'A'; row < 'A' + TotalSeats / 4; row++)
            {
                for (int seatNumber = 1; seatNumber <= 4; seatNumber++)
                {
                    string seat = $"{row}{seatNumber}";
                    if (!BookedSeats.Contains(seat))
                    {
                        Console.Write($"{seat} ");
                    }
                    else
                    {
                        Console.Write("X  ");
                    }
                }
                Console.WriteLine();
            }
        }

        private bool IsValidSeat(string seat)
        {
            if (seat.Length != 2)
            {
                return false;
            }

            char row = seat[0];
            int seatNumber;

            if (!char.IsLetter(row) || !int.TryParse(seat[1].ToString(), out seatNumber))
            {
                return false;
            }

            if (row < 'A' || row > 'I' || seatNumber < 1 || seatNumber > 4)
            {
                return false;
            }

            return true;
        }

        public bool BookSeat(string seat)
        {
            if (!IsValidSeat(seat) || BookedSeats.Contains(seat))
            {
                Console.WriteLine("Geçersiz koltuk numarası veya seçilen koltuk rezerve edilemez.");
                return false;
            }

            Console.Write("Adınız: ");
            string firstName = Console.ReadLine();
            Console.Write("Soyadınız: ");
            string lastName = Console.ReadLine();
            Console.Write("Yaşınız: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Geçersiz yaş. Lütfen doğru bir yaş girin.");
                Console.Write("Yaşınız: ");
            }

            Passenger = new Passenger
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            Console.WriteLine("Ödeme Bilgileri:");
            Payment payment = Payment.GetPaymentDetails();

            TicketNumber = GenerateTicketNumber();

            BookedSeats.Add(seat);
            Console.WriteLine("Rezervasyonunuz başarıyla tamamlandı. Teşekkür ederiz!");
            Console.WriteLine($"Bilet Numaranız: {TicketNumber}");

            SaveReservationToTxt(TicketNumber, this, seat, Passenger, payment);

            return true;
        }

        private static string GenerateTicketNumber()
        {
            Random random = new Random();
            return random.Next(100, 1000).ToString();
        }

        public static void SaveReservationToTxt(string ticketNumber, Flight flight, string seat, Passenger passenger, Payment payment)
        {
            string reservationDetails = $"Ticket Number: {ticketNumber}, Flight: {flight.FlightNumber}, Seat: {seat}, " +
                                        $"Passenger: {passenger.FirstName} {passenger.LastName}, Age: {passenger.Age}, " +
                                        $"Payment: Card ending in {payment.CardNumber.Substring(payment.CardNumber.Length - 4)}";

           
            string folderPath = "Data";
 
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "reservations.txt");
            File.AppendAllLines(filePath, new[] { reservationDetails });
        }



    }


}