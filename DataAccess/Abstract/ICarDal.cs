using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
  public  interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> getCarDetail();

        //List<Car> GetCarsByBrandId(int brandId);
        //List<Car> GetCarsByColorId(int colorId);

        //List<Car> GetAll();
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //List<Car> GetAllByBrands(int brandId);
        //List<Car> GetById(int id);

        //List<Brands>GetAllByBrands2(Brands brands);
    }
}
