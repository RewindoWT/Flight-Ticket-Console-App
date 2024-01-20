// Payment.cs

namespace GALA_FLY_Ticket_App.Models
{
    public class Payment
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }



        public void ProcessPayment(decimal amount)
        {
            // Ödeme işlemleri burada gerçekleştirilebilir.
            Console.WriteLine($"Ödeme başarıyla gerçekleştirildi. Ödenen Tutar: {amount:C}");
        }

        public static Payment GetPaymentDetails()
        {
            Payment payment = new Payment();

            // Kart Numarası giriş kontrolü
            do
            {
                Console.Write("Kart Numaranız (16 haneli): ");
                payment.CardNumber = Console.ReadLine();
            } while (payment.CardNumber.Length != 16);

            // Son Kullanma Tarihi giriş kontrolü
            do
            {
                Console.Write("Son Kullanma Tarihi (MM/YYYY) Ornek input 12/2025 : ");
                payment.ExpiryDate = Console.ReadLine();
            } while (!IsValidExpiryDate(payment.ExpiryDate));

            // CVV giriş kontrolü
            do
            {
                Console.Write("CVV (100-999): ");
                payment.CVV = Console.ReadLine();
            } while (!IsValidCVV(payment.CVV));

            return payment;
        }

        private static bool IsValidExpiryDate(string expiryDate)
        {
            if (expiryDate.Length != 7)
                return false;

            string[] parts = expiryDate.Split('/');
            if (parts.Length != 2)
                return false;

            if (!int.TryParse(parts[0], out int month) || month < 1 || month > 12)
                return false;

            if (!int.TryParse(parts[1], out int year) || year < DateTime.Now.Year || year > DateTime.Now.Year + 5)
                return false;

            return true;
        }

        private static bool IsValidCVV(string cvv)
        {
            return int.TryParse(cvv, out int cvvValue) && cvvValue >= 100 && cvvValue <= 999;
        }




    }
}