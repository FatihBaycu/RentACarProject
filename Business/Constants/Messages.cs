using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
   {
       public static string CarAdded = "Araç Eklendi.";
       public static string CarNotAdded = "Araç Eklendemedi.";
       public static string CarDeleted = "Araç Silindi.";
       public static string CarNotDeleted = "Araç Silinemedi.";
       public static string CarsListedByBrand = "Araçlar Markaya Göre Sıralandı";
       public static string Listed = "Listelendi.";
       public static string NotListed = "Listelenmedi.";
       public static string Added = "Eklendi.";
       public static string Updated = "Güncellendi.";
       public static string Deleted = "Silindi.";
       public static string CarImageAdded = "Araba resmi eklendi";
       public static string CarImageUpdated = "Araba resmi güncellendi";
       public static string CarImageDeleted = "Araba resmi silindi";
       public static string CarImageLimited = "Araç resmi maksimum";
       public static string AuthorizationDenied = "Erişim Reddedildi";
       public static string UserRegistered = "Kullanıcı Kayıt Oldu.";
       public static string UserNotFound = "Kullanıcı Bulunamadı.";
       public static string PasswordError = "Parola Hatalı.";
       public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
       public static string UserAlreadyExists = "Kullanıcı zaten mecvut.";
       public static string AccessTokenCreated = "Acces Token oluşturuldu.";

       public static string CarImageNumberError = "A car cannot have more than 5 images.";
       public static string CarImageNotFound = "Car image not found";
   }
}
