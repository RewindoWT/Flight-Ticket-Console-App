# Flight-Ticket-Consoleapp

Kullanim ; Ucus ayarla denildikten sonra 3 tane ucak numarasindan birini secerek ucus belirliyorsunuz. Sonra koltuk numarasi seciminde eger databasenin icinde rezervasyon varsa rezervasyonu olan koltuklar dolu gozukecektir. 
Ilk basta data bos oldugu icin koltuklar bos gozukecektir
A1 koltugu sectikten sonra rezervasyonu tamamladiktan sonra bu bilgiler database uzerine kaydedilir
2. kez Ucus ayarlamak istediginizde ilk basta rezervasyon yaptiginiz A1 koltugu dolu gozukecektir. 
Rezervasyon goruntule diyince Her rezervasyon sonu verilen unique bir bilet numarasi olacaktir onlar gozukup rezervasyon bilgileri gozukecektir.


# Uçak Bilet Rezervasyon Konsol Uygulaması

Bu konsol uygulaması, uçak bilet rezervasyon işlemlerini gerçekleştirmek için tasarlanmıştır. Uygulama, Object-Oriented Programming (OOP) prensiplerine uygun olarak Airport, Flight, Location, Passenger ve Payment sınıflarını içermektedir.

## Kurulum

Proje dosyalarını indirin ve bir C# derleyicisi ile derleyin. Ardından, uygulamayı çalıştırarak başlayabilirsiniz.

## Kullanım

Uygulama, konsol üzerinden kullanıcı etkileşimi ile çalışmaktadır. Kullanıcıya, uçuşları arama, bilet rezerve etme, yolcu bilgilerini girmeye ve ödeme işlemlerini gerçekleştirmeye olanak tanır.

### Sınıflar

1. **Airport.cs**: Havaalanını temsil eden sınıf. Havaalanının adı, kodu ve konumu gibi özellikleri içerir.

2. **Flight.cs**: Uçuş bilgilerini tutan sınıf. Kalkış ve varış havaalanları, kalkış tarihi, varış tarihi gibi uçuş detaylarını içerir.

3. **Location.cs**: Konumu temsil eden sınıf. Şehir, ülke gibi bilgileri içerir.

4. **Passenger.cs**: Yolcu bilgilerini içeren sınıf. Ad, soyad, kimlik numarası gibi özellikleri içerir.

5. **Payment.cs**: Ödeme bilgilerini içeren sınıf. Kart numarası, son kullanma tarihi gibi bilgileri içerir.


