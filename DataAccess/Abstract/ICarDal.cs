﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
  public  interface ICarDal:IEntityRepository<Car>
    {
        //List<Car> GetAll();
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //List<Car> GetAllByBrands(int brandId);
        //List<Car> GetById(int id);

        //List<Brands>GetAllByBrands2(Brands brands);
    }
}
