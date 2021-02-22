using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }


        public void Add(Car car)
        {

            if (car.Description.Length <= 2)
            {
                Console.WriteLine("Açıklama uzunluğu 2 harfden uzun olmalıdır.");
            }
            else if (car.DailyPrice <= 1)
            {
                Console.WriteLine("Günlük Fiyat 0 TL den büyük olmalıdır.");
            }

            else
            {
                _iCarDal.Add(car);
                Console.WriteLine("Kayıt Eklendi.\n");
            }


        }
        public void Update(Car car)
        {
            if (car.Description.Length <= 2)
            {
                Console.WriteLine("Açıklama uzunluğu 2 harfden uzun olmalıdır.");
            }
            else if (car.DailyPrice <= 1)
            {
                Console.WriteLine("Günlük Fiyat 0 TL den büyük olmalıdır.");
            }

            else
            {
                _iCarDal.Update(car);
                Console.WriteLine("Kayıt Güncellendi.\n");
            }

        }

        public void Delete(Car car)
        {
            _iCarDal.Delete(car);

        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(p => p.ColorId == colorId);
        }
    }
}
