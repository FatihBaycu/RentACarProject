using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspect.Autofac.Validation;
using Core.Results;
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

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                //return new ErrorDataResult<List<Car>>(Messages.NotListed);
                return new ErrorDataResult<List<Car>>("Saat 22 de bakımdayız.");
            }
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(),Messages.Listed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
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
                _iCarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
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

        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == brandId),true,Messages.CarsListedByBrand);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<List<CarDetailsDto>> getCarDetail()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_iCarDal.getCarDetail());
        }
    }
}
