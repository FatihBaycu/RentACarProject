using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.Id == carId), Messages.Listed);
        }

        public IDataResult<CarDetailsDto> GetDetailById(int carId)
        {
            return new SuccessDataResult<CarDetailsDto>(_iCarDal.GetCarDetailsById(c=>c.Id==carId));
        }

        [SecuredOperation("car.add,admin")]
        //[ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            //if (car.Description.Length <= 2)
            //{
            //    Console.WriteLine("Açıklama uzunluğu 2 harfden uzun olmalıdır.");
            //    return new ErrorResult(Messages.CarNotAdded);
            //}
            //else if (car.DailyPrice <= 1)
            //{
            //    Console.WriteLine("Günlük Fiyat 0 TL den büyük olmalıdır.");
            //    return new ErrorResult(Messages.CarNotAdded);

            //}

            
                _iCarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            
        }

        public IResult Delete(Car car)
        {

            _iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }//BU MANAGER 

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                //return new ErrorDataResult<List<Car>>(Messages.NotListed);
                return new ErrorDataResult<List<Car>>("Saat 3 de bakımdayız.");
            }
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_iCarDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_iCarDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_iCarDal.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId));

        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_iCarDal.GetCarDetails(c => c.ColorId == colorId && c.BrandId == brandId));

        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByCar(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_iCarDal.GetCarDetails(c => c.Id == carId));
        }

        public IDataResult<CarDetailsDto> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailsDto>(_iCarDal.GetCarDetailsById(c => c.Id == id));
        }

         [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.ColorId == colorId), Messages.Listed);
        }

        //public IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == colorId), Messages.Listed);
        //}

        public IResult TransactionalOperation(Car car)
        {
            _iCarDal.Update(car);
            _iCarDal.Add(car);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Update(Car car)
        {
            if (car.Description.Length <= 2)
            {
                Console.WriteLine("Açıklama uzunluğu 2 harfden uzun olmalıdır.");
                return new ErrorResult(Messages.CarNotAdded);

            }
            else if (car.DailyPrice <= 1)
            {
                Console.WriteLine("Günlük Fiyat 0 TL den büyük olmalıdır.");
                return new ErrorResult(Messages.CarNotAdded);

            }
            else
            {
                _iCarDal.Update(car);
                Console.WriteLine("Kayıt Güncellendi.\n");
                return new SuccessResult(Messages.CarAdded);

            }
        }

        public IResult TransactionalTest(Car car)
        {
            _iCarDal.Update(car);
            _iCarDal.Add(car);
            return new SuccessResult(Messages.Added);
        }
    }
}
