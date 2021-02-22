using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            goto a1;
              a1:
            CarManager carManager = new CarManager(new EfCarDal());
            // carManager.GetCarsByBrandId();

          
            int secim = 0;
            Console.WriteLine("İşlem Seçiniz\n-1- Araçları Görüntüle\n-2- Araç Ekle\n");
            secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1: ShowTheCars(carManager); break;
                case 2: AracEkle(carManager); break;
                default: Console.WriteLine("Yanlış Seçim yaptınız.\n"); break;
                        
            }

            goto a1;
          
            Console.ReadKey();

        }

        private static void AracEkle(CarManager carManager)
        {
            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 12,
                Description = "abca",
                ModelYear = 2019
            });
        }

        private static void ShowTheCars(CarManager carManager)
        {
            foreach (var item in carManager.GetAll())
            {
                //Console.WriteLine(item.BrandId+""+item.Description);
                Console.WriteLine("Araba Id: " + item.Id + "\nAraba Marka: " + item.BrandId + "\nAraba Renk: " + item.ColorId +
                                  "\nAraba Model Yılı: " + item.ModelYear + "\nAraba Günlük Ücreti: " + item.DailyPrice +
                                  " TL\nAraba Açıklaması: " + item.Description+"\n");
                Console.WriteLine(
                    "-----------------------------------------------------------------------------------------------------------------------");
            }
        }
    }
}
