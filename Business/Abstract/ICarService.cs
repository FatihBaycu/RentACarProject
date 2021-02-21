using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    interface ICarService
    {
      //  List<Car> GetAll();

      void Add(Car car);
      void Update(Car car);
      
      
      
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);

    }
}
