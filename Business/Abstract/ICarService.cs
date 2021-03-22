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
      //  IDataResult<List<Car>> GetAll();
        
      //  IResult Add(Car car);
      //  IResult Update(Car car);
      //  IResult Delete(Car car);

      ////IDataResult<List<Car>> GetCarsByBrandId(int brandId);
      ////IDataResult<List<Car>> GetCarsByColorId(int colorId);
      //IDataResult<List<CarDetailsDto>> GetCarDetail();
      //IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int brandId);
      //IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorId);
      //IDataResult<List<CarDetailsDto>> GetCarDetails();
      //IDataResult<CarDetailsDto> GetCarDetailsById(int id);
      //  IResult TransactionalOperation(Car car);


        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailsByBrand(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByColor(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByCar(int carId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<Car> GetById(int carId);
        IDataResult<CarDetailsDto> GetDetailById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IResult TransactionalTest(Car car);


    }
}
