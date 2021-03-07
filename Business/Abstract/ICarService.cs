using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

      IDataResult<List<Car>> GetCarsByBrandId(int brandId);
      IDataResult<List<Car>> GetCarsByColorId(int colorId);
      IDataResult<List<CarDetailsDto>> getCarDetail();

      IResult TransactionalOperation(Car car);


    }
}
