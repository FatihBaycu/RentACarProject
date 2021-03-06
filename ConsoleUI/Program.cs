using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           // UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            GetRentalsDetailTest(rentalManager);

         


            //UserTest(userManager);
            //CustomerTest(customerManager);
            //RentalTest(rentalManager);

            Test(carManager, colorManager, brandManager);
            goto a1;
        }

        private static void GetRentalsDetailTest(RentalManager rentalManager)
        {
            foreach (var rentals in rentalManager.getRentalsDetail().Data)
            {
                Console.WriteLine(rentals.CarName + "\n" + rentals.CompanyName + "\n" + rentals.FirstName + "\n" +
                                  rentals.LastName + "\n--------------------------\n");
            }
        }

        private static void RentalTest(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now });
            foreach (var rent in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rent.CustomerId);
            }

            rentalManager.Update(new Rental { Id = 5, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now });
            rentalManager.Delete(new Rental { Id = 6 });
        }

        //private static void UserTest(UserManager userManager)
        //{
        //    userManager.Add(new User { Email = "e", FirstName = "a", LastName = "b", Password = "1" });
        //    foreach (var users in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(users.FirstName);
        //    }

        //    userManager.Update(new User { Id = 3, Email = "E", FirstName = "A", LastName = "B", Password = "1" });
        //    userManager.Delete(new User { Id = 4 });
        //}

        private static void CustomerTest(CustomerManager customerManager)
        {
            customerManager.Add(new Customer { CompanyName = " A Şirketi", UserId = 1 });
            foreach (var customers in customerManager.GetAll().Data)
            {
                Console.WriteLine("Şirket Adı: " + customers.CompanyName + "User Id: " + customers.UserId);
            }

            customerManager.Update(new Customer { CompanyName = " X Şirketi", UserId = 6, Id = 7 });
            customerManager.Delete(new Customer { Id = 6 });
        }

        private static void Test(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            int selectTable;
            Console.WriteLine("-----Konu Seçiniz-----\n-1- Araçlar\n-2- Renkler\n-3- Markalar\n");

            selectTable = Convert.ToInt32(Console.ReadLine());
            switch (selectTable)
            {
                case 1:
                    int secim = 0;
                    Console.WriteLine(
                        "-----İşlem Seçiniz-----\n-1- Araçları Görüntüle\n-2- Araç Ekle\n-3- Araç Güncelle\n-4- Araç Sil\n-5- GetAll Komutu\n");
                    secim = Convert.ToInt32(Console.ReadLine());
                    switch (secim)
                    {
                        case 1:
                            ShowTheCars(carManager);
                            break;
                        case 2:
                            AddCar(carManager);
                            break;
                        case 3:
                            UpdateCar(carManager);
                            break;
                        case 4:
                            DeleteCar(carManager);
                            break;
                        case 5:
                            GetAll(carManager);
                            break;
                        default:
                            Console.WriteLine("Yanlış Seçim yaptınız.\n");
                            break;
                    }

                    ;
                    break;


                case 2:
                    int secim2 = 0;
                    Console.WriteLine(
                        "-----İşlem Seçiniz-----\n-1- Renkleri Görüntüle\n-2- Renk Ekle\n-3- Renk Güncelle\n-4- Rrnk Sil\n-5- Id ye göre Komutu\n");
                    secim2 = Convert.ToInt32(Console.ReadLine());
                    switch (secim2)
                    {
                        case 1:
                            ColorTest(colorManager);
                            break;
                        case 2:
                            AddColor(colorManager);
                            break;
                        case 3:
                            UpdateColor(colorManager);
                            break;
                        case 4:
                            DeleteColor(colorManager);
                            break;
                        case 5:
                            GetColorById(colorManager);
                            break;
                        default:
                            Console.WriteLine("Yanlış Seçim yaptınız.\n");
                            break;
                    }

                    ;
                    break;
                case 3:
                    int secim3 = 0;
                    Console.WriteLine(
                        "-----İşlem Seçiniz-----\n-1- Markaları Görüntüle\n-2- Marka Ekle\n-3- Marka Güncelle\n-4- Marka Sil\n-5- Id ye göre Komutu\n");
                    secim3 = Convert.ToInt32(Console.ReadLine());
                    switch (secim3)
                    {
                        case 1:
                            BrandsGetAll(brandManager);
                            break;
                        case 2:
                            AddBrand(brandManager);
                            break;
                        case 3:
                            UpdateBrand(brandManager);
                            break;
                        case 4:
                            DeleteBrand(brandManager);
                            break;
                        case 5:
                            BrandsGetById(brandManager);
                            break;
                        default:
                            Console.WriteLine("Yanlış Seçim yaptınız.\n");
                            break;
                    }

                    ;
                    ;
                    break;
                default:
                    Console.WriteLine("Yanlış Seçim yaptınız.\n");
                    break;
            }

            return;
        }


        /*BRAND*/
        private static void DeleteBrand(BrandManager brandManager)
        {
            int deletedId;
            Console.WriteLine("Silinecek Marka Id si giriniz: ");
            deletedId = Convert.ToInt32(Console.ReadLine());
            brandManager.Delete(new Brand { BrandId = deletedId });
        }

        private static void UpdateBrand(BrandManager brandManager)
        {
            int uptatedId;
            string brandName;
            Console.WriteLine("Güncellencek Marka Id si giriniz: ");
            uptatedId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Güncellencek Marka Adı giriniz: ");
            brandName = Console.ReadLine();
            brandManager.Update(new Brand { BrandId = uptatedId, BrandName = brandName });
        }

        private static void AddBrand(BrandManager brandManager)
        {
            string brandName;
            Console.WriteLine("Eklenecek Marka Adı giriniz: ");
            brandName = Console.ReadLine();
            brandManager.Add(new Brand { BrandName = brandName });
        }

        private static void BrandsGetById(BrandManager brandManager)
        {
            int getId;
            Console.WriteLine("Listelencek Marka Id si giriniz: ");
            getId = Convert.ToInt32(Console.ReadLine());

            foreach (var brands in brandManager.GetById(getId).Data)
            {
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void BrandsGetAll(BrandManager brandManager)
        {
            foreach (var brands in brandManager.GetAll().Data)
            {


                Console.WriteLine(brands.BrandName);
            }
        }
        // CAR //
        private static void ColorTest(ColorManager colorManager)
        {
            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine(colors.ColorName);
            }

        }

        private static void GetColorById(ColorManager colorManager)
        {
            int getId;
            Console.WriteLine("Listelencek Marka Id si giriniz: ");
            getId = Convert.ToInt32(Console.ReadLine());
            foreach (var colors in colorManager.GetByColorId(getId).Data)
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void DeleteColor(ColorManager colorManager)
        {
            int getId;
            Console.WriteLine("Silineck Renk Id si giriniz: ");
            getId = Convert.ToInt32(Console.ReadLine());
            colorManager.Delete(new Color() { ColorId = 6 });
        }

        private static void UpdateColor(ColorManager colorManager)
        {
            int getId;
            string uptatedName, uptatedColorCode;
            Console.WriteLine("Güncellencek Renk Id si giriniz: ");
            getId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Güncellencek Renk Adı giriniz: ");
            uptatedName = Console.ReadLine();
            Console.WriteLine("Güncellencek Renk Kodu giriniz: ");
            uptatedColorCode = Console.ReadLine();
            colorManager.Update(new Color { ColorId = 5, ColorCode = "", ColorName = "Gri" });
        }

        private static void AddColor(ColorManager colorManager)
        {
            string addColor, addColorCode;
            Console.WriteLine("Eklenecek Renk Adı giriniz: ");
            addColor = Console.ReadLine();
            Console.WriteLine("Eklenecek Renk Kodu giriniz: ");
            addColorCode = Console.ReadLine();
            colorManager.Add(new Color { ColorCode = addColorCode, ColorName = addColor });
        }
        // CAR //
        private static void GetAll(CarManager carManager)
        {
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.Description);
            }
        }

        private static void UpdateCar(CarManager carManager)
        {
            int carId, brandId, colorId, modelYear;
            decimal dailyPrice;
            string description, carName;

            Console.WriteLine("Araba Id: ");
            carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marka Id: ");
            brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Renk Id: ");
            colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Günlük Ücret: ");
            dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Açıklama: ");
            description = Console.ReadLine();
            Console.WriteLine("Araba Adı: ");
            carName = Console.ReadLine();
            Console.WriteLine("Model Yılı: ");
            modelYear = Convert.ToInt32(Console.ReadLine());

            try
            {
                carManager.Update(new Car
                {
                    Id = carId,
                    BrandId = brandId,
                    ColorId = colorId,
                    DailyPrice = dailyPrice,
                    Description = description,
                    CarName = carName,
                    ModelYear = modelYear
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Yanlış Değer Girdiniz!!\n"+e.Message);
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
                Console.WriteLine("Yanlış Değer Girdiniz!!\n"+e.Message);
            }

        }



        private static void AddCar(CarManager carManager)
        {
            int brandId, colorId, modelYear;
            decimal dailyPrice;
            string description, carName;
            Console.WriteLine("Marka Id: ");
            brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Renk Id: ");
            colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Günlük Ücret: ");
            dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Açıklama: ");
            description = Console.ReadLine();
            Console.WriteLine("Araba Adı: ");
            carName = Console.ReadLine();
            Console.WriteLine("Model Yılı: ");
            modelYear = Convert.ToInt32(Console.ReadLine());
            // sonradan eklencek girilen değerler ile veri kaydı.
            // Console.WriteLine("Sırasıyla Değerleri Giriniz: BrandId--ColorId--DailyPrice--Description--ModelYear--CarName ");

            carManager.Add(new Car
            {
                BrandId = brandId,
                ColorId = colorId,
                DailyPrice = dailyPrice,
                Description = description,
                CarName = carName,
                ModelYear = modelYear
            });
        }

        private static void ShowTheCars(CarManager carManager)
        {
            var result = carManager.GetAll().Data;
            foreach (var item in result)
            {
                //Console.WriteLine(item.BrandId+""+item.Description);
                Console.WriteLine("Araba Id: " + item.Id + "\nAraba Marka: " + item.BrandId + "\nAraba Adı: " + item.CarName + "\nAraba Renk: " + item.ColorId +
                                  "\nAraba Model Yılı: " + item.ModelYear + "\nAraba Günlük Ücreti: " + item.DailyPrice +
                                  " TL\nAraba Açıklaması: " + item.Description + "\n");
                Console.WriteLine(
                    "-----------------------------------------------------------------------------------------------------------------------");
            }
        }
        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var item in carManager.getCarDetail().Data)
            {
                Console.WriteLine("Araba Marka: " + item.BrandName + "\nAraba Model: " + item.CarName + "\nAraba Rengi: " +
                                  item.ColorName + "\nAraba Günlük Fiyatı: " + item.DailyPrice +
                                  "\n----------------------------------------------------");
            }
            // carManager.GetCarsByBrandId();
            //GetCarDetails(carManager);
        }
    }
}
