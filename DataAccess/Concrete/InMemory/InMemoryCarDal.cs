using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _car;
        private List<Colors> _colors;
        private List<Brands> _brands;

        public InMemoryCarDal()
        {
            _colors = new List<Colors>
            {
                new Colors(){ColorId = 1,ColorName = "RED",ColorCode = "#FF0000"},
                new Colors(){ColorId = 2,ColorName = "WHITE",ColorCode = "#FFFFFF"},
            };

            _brands = new List<Brands>
            {
                new Brands(){BrandId = 1,BrandName = "Ford"},
                new Brands(){BrandId = 2,BrandName = "Audi"},
            };



            _car = new List<Car>
            {
                new Car() {Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 120,ModelYear = 2019,Description = "Günlük kullanım için gayet uygun aile aracı"},
                new Car() {Id = 2,BrandId = 1,ColorId = 2,DailyPrice = 130,ModelYear = 2019,Description = "Günlük kullanım için gayet uygun aile aracı"}

            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(p => p.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAllByBrands(int brandsId)
        {
            return _car.Where(p => p.BrandId==brandsId).ToList();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
