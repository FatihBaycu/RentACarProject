using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
     List<Car> GetAll();

      void Add(Car car);
      void Update(Car car);

      void Delete(Car car);
      
      List<Car> GetCarsByBrandId(int brandId);
      List<Car> GetCarsByColorId(int colorId);
      List<CarDetailsDto> getCarDetail();

    }
}
