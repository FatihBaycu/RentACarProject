using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            // carManager.GetCarsByBrandId();
            // ColorTest(colorManager);
            //BrandTest(brandManager);

            foreach (var item in carManager.getCarDetail())
            {
                Console.WriteLine("Araba Marka: " + item.BrandName + "\nAraba Model: " + item.CarName + "\nAraba Rengi: " + item.ColorName + "\nAraba Günlük Fiyatı: " + item.DailyPrice + "\n----------------------------------------------------");

            }



            int secim = 0;
            Console.WriteLine("-----İşlem Seçiniz-----\n-1- Araçları Görüntüle\n-2- Araç Ekle\n-3- Araç Güncelle\n-4- Araç Sil\n-5- GetAll Komutu\n");
            secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1: ShowTheCars(carManager); break;
                case 2: AddCar(carManager); break;
                case 3: UpdateCar(carManager); break;
                case 4: DeleteCar(carManager); break;
                case 5: GetAll(carManager); break;
                default: Console.WriteLine("Yanlış Seçim yaptınız.\n"); break;
            }
            goto a1;
            Console.ReadKey();
        }

        private static void BrandTest(BrandManager brandManager)
        {
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine(brands.BrandName);
            }

            foreach (var brands in brandManager.GetById(1))
            {
                Console.WriteLine(brands.BrandName);
            }

            brandManager.Add(new Brand {BrandName = "Ford"});
            brandManager.Update(new Brand {BrandId = 1, BrandName = "MARKADEĞİŞTİ"});
            brandManager.Delete(new Brand {BrandId = 6});
        }

        private static void ColorTest(ColorManager colorManager)
        {
            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }

            colorManager.Add(new Color {ColorCode = "", ColorName = "Yeşil"});
            colorManager.Update(new Color {ColorId = 5, ColorCode = "", ColorName = "Gri"});
            colorManager.Delete(new Color() {ColorId = 6});
            foreach (var colors in colorManager.GetByColorId(1))
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
        }

        private static void UpdateCar(CarManager carManager)
        {
            int updatedId;
            Console.WriteLine("Güncellenicek Id'yi Giriniz: ");

            updatedId = Convert.ToInt32(Console.ReadLine());
            try
            {
                carManager.Update(new Car
                {
                    Id = updatedId,
                    BrandId = 2,
                    ColorId = 2,
                    DailyPrice = 120,
                    Description = "Aile Arabası",
                    ModelYear = 2019
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Yanlış Değer Girdiniz!!\n");
            }
            
        }


        private static void DeleteCar(CarManager carManager)
        {
            int deletedId;
            Console.WriteLine("Silinicek Id'yi Giriniz: ");

            deletedId = Convert.ToInt32(Console.ReadLine());
            try
            {
                carManager.Delete(new Car() { Id = deletedId });
                Console.WriteLine(deletedId + " id li araç silindi.\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("Yanlış Değer Girdiniz!!\n");
            }

        }



        private static void AddCar(CarManager carManager)
        {

            // sonradan eklencek girilen değerler ile veri kaydı.
            // Console.WriteLine("Sırasıyla Değerleri Giriniz: BrandId--ColorId--DailyPrice--Description--ModelYear--CarName ");

            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 160,
                Description = "Günlük Kullanımma Uygun Araç",
                CarName = "Jetta",
                ModelYear = 2019
            });
        }

        private static void ShowTheCars(CarManager carManager)
        {
            foreach (var item in carManager.GetAll())
            {
                //Console.WriteLine(item.BrandId+""+item.Description);
                Console.WriteLine("Araba Id: " + item.Id + "\nAraba Marka: " + item.BrandId + "\nAraba Adı: " + item.CarName + "\nAraba Renk: " + item.ColorId +
                                  "\nAraba Model Yılı: " + item.ModelYear + "\nAraba Günlük Ücreti: " + item.DailyPrice +
                                  " TL\nAraba Açıklaması: " + item.Description + "\n");
                Console.WriteLine(
                    "-----------------------------------------------------------------------------------------------------------------------");
            }
        }
    }
}
