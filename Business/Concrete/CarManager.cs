using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
  public  class CarManager:ICarService
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
    }
}
