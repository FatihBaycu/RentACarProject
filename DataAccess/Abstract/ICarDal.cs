using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
  public  interface ICarDal:IEntityRepository<Car>
    {

        //List<Car> GetCarsByBrandId(int brandId);
        //List<Car> GetCarsByColorId(int colorId);

        //List<Car> GetAll();
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //List<Car> GetAllByBrands(int brandId);
        //List<Car> GetById(int id);

        //List<Brands>GetAllByBrands2(Brands brands);
        List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailsDto GetCarDetailsById(Expression<Func<Car, bool>> filter);
    }
}
