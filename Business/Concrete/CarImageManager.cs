using System;
using System.Collections.Generic;
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
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), true, Messages.Listed);
        }

        //[SecuredOperation("admin,carimage.add")]
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.AddFile(file);

            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }


        [SecuredOperation("admin,carimage.delete")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);

            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            FileHelper.DeleteFile(image.ImagePath);

            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }


        [SecuredOperation("admin,carimage.update")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldImage = _carImageDal.Get(c => c.Id == carImage.Id);

            if (oldImage == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.UpdateFile(file, oldImage.ImagePath);

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
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


        // Business Rules Methods
        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageNumberError);
            }

            return new SuccessResult();
        }









        //    DateTime dateNow = Convert.ToDateTime(Convert.ToString(DateTime.Now));
        //    public IResult Add(CarImage carImage)
        //    {
        //        IResult result = BusinessRules.Run(CheckCarImageCount(carImage.CarId), CheckIfCarImageNull(carImage), SetDateTime(carImage));
        //        if (result != null)
        //        {
        //            return new ErrorResult();
        //        }
        //        //carImage.Date = Convert.ToDateTime(Convert.ToString(DateTime.Now));
        //        // carImage.Date = dateNow;
        //        _carImageDal.Add(carImage);
        //        return new SuccessResult(Messages.CarImageAdded);


        //    }
        //    public IResult Update(CarImage carImage)
        //    {
        //        IResult result = BusinessRules.Run(CheckCarImageCount(carImage.CarId), CheckIfCarImageNull(carImage), SetDateTime(carImage));

        //        if (result != null)
        //        { return new ErrorResult("sdfsd"); }
        //        // carImage.Date = dateNow;
        //        _carImageDal.Update(carImage);
        //        return new SuccessResult(Messages.CarImageUpdated);




        //    }
        //    public IResult Delete(CarImage carImage)
        //    {
        //        _carImageDal.Delete(carImage);
        //        return new SuccessResult(Messages.CarImageDeleted);
        //    }

        //    public IDataResult<List<CarImage>> GetAll()
        //    {
        //        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), true, Messages.Listed);
        //    }





        //    private IResult CheckCarImageCount(int carId)
        //    {
        //        var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
        //        if (result >= 5)
        //        {
        //            return new ErrorResult(Messages.CarImageLimited);
        //        }

        //        return new SuccessResult();
        //    }

        //    private IResult CheckIfCarImageNull(CarImage carImage)
        //    {
        //        if (carImage.ImagePath == null)
        //            carImage.ImagePath = @"C:\Users\Fatih\source\repos\ReCapProject\WepAPI\CarImages\defaultImage.png";
        //        return new SuccessResult();
        //    }

        //    private IResult SetDateTime(CarImage carImage)
        //    {
        //        carImage.Date = dateNow;
        //        return new SuccessResult();
        //    }
        //}
    }
}