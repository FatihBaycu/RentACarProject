using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
