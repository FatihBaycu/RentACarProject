using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            var getListByCarId = _carImageDal.GetAll(car => car.CarId == carId);

            if (getListByCarId.Count > 0)
                return new SuccessDataResult<List<CarImage>>(getListByCarId);

            var path = "Uploads/Images/CarImages/defaultImage.png";
            var defaultImage = new List<CarImage> { new CarImage { ImagePath = path } };

            return new SuccessDataResult<List<CarImage>>(defaultImage);
        }

        //[SecuredOperation("admin,carimage.add")]
        //[ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = SaveImage(file);

            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.Added);
        }


        //[SecuredOperation("admin,carimage.delete")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            DeleteImage(carImage.Id);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.Deleted);
        }

        //[SecuredOperation("admin,carimage.update")]
        //[ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            carImage.Date = DateTime.Now;
            carImage.ImagePath = UpdateImage(carImage.Id, file);

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.Updated);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == carImageId));
        }

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageNumberError);
            }

            return new SuccessResult();
        }


        private string SaveImage(IFormFile file)
        {
            return FileHelperAsync.ImageSave(file).Result.ToString();
        }

        private void DeleteImage(int carImageId)
        {
            var carImage = _carImageDal.Get(c => c.Id == carImageId);
            var path = carImage.ImagePath;
 
            File.Delete(Directory.GetParent(Directory.GetCurrentDirectory()) + PathNames.BaseName + path);
        }

        private string UpdateImage(int carImageId, IFormFile file)
        {
            DeleteImage(carImageId);
            return SaveImage(file);
        }
    }
}