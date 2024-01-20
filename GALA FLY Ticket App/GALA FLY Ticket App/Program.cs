// Program.cs
using System;
using GALA_FLY_Ticket_App.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("           _");
        Console.WriteLine("         -=\\`\\");
        Console.WriteLine("     |\\ ____\\_\\__");
        Console.WriteLine("   -=\\c`\"\"\"\"\"\"\" \"`)");
        Console.WriteLine("      `~~~~~/ /~~`");
        Console.WriteLine("        -==/ /");
        Console.WriteLine("          '-'");

        Console.WriteLine("GALA Flight Reservation System\n");

        FlightReservationSystem reservationSystem = new FlightReservationSystem();

        do
        {
            Console.WriteLine("Ana Menu");
            Console.WriteLine("1. Tum ucuslari goruntule");
            Console.WriteLine("2. Ucus ayarla");
            Console.WriteLine("3. Reservation goruntule");
            Console.WriteLine("4. Cikis");
            Console.WriteLine("M. Menu");

            Console.Write("Seciminizi yapiniz: ");
            string input = Console.ReadLine().ToUpper();

            if (input == "M")
            {
                continue;
            }

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        reservationSystem.DisplayAllFlights();
                        break;
                    case 2:
                        reservationSystem.BookFlight();
                        break;
                    case 3:
                        reservationSystem.DisplayReservations();
                        break;
                    case 4:
                        Console.WriteLine("Çıkış yapılıyor. İyi uçuşlar!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Hatali secim. Tekrar deneyin.");
                        break;
                }
            }
            else if (!reservationSystem.ValidateSeatInput(input))
            {
                Console.WriteLine("Geçersiz koltuk formatı. Lütfen doğru formatta girin (Örnek: A1).");
            }

        } while (true);
    }
}
