using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.GetAll();

            foreach (var item in carManager.GetAll())
            {
                //Console.WriteLine(item.BrandId+""+item.Description);
                Console.WriteLine("Araba Id: "+item.Id+"\nAraba Marka: "+item.BrandId+"\nAraba Renk: "+item.ColorId+"\nAraba Model Yılı: "+item.ModelYear+"\nAraba Günlük Ücreti: "+item.DailyPrice+" TL\nAraba Açıklaması: "+item.Description);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            }

            Console.ReadKey();

        }
    }
}
