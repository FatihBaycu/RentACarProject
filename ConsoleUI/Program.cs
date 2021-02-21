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
            CarManager carManager = new CarManager(new EfCarDal());
            // carManager.GetCarsByBrandId();

            foreach (var item in carManager.GetCarsByBrandId(1))
            {
                //Console.WriteLine(item.BrandId+""+item.Description);
                Console.WriteLine("Araba Id: " + item.Id + "\nAraba Marka: " + item.BrandId + "\nAraba Renk: " + item.ColorId + "\nAraba Model Yılı: " + item.ModelYear + "\nAraba Günlük Ücreti: " + item.DailyPrice + " TL\nAraba Açıklaması: " + item.Description);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                carManager.Add(new Car
                {
                    BrandId = 2,
                    ColorId = 2,
                    DailyPrice = 12,
                    Description = "abca",
                    Id = 2,
                    ModelYear = 2019
                });

            }



            Console.ReadKey();

        }
    }
}
