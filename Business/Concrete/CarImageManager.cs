using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        DateTime dateNow = Convert.ToDateTime(Convert.ToString(DateTime.Now));
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carImage.CarId), CheckIfCarImageNull(carImage), SetDateTime(carImage));
            if (result != null)
            {
                return new ErrorResult();
            }
            //carImage.Date = Convert.ToDateTime(Convert.ToString(DateTime.Now));
            // carImage.Date = dateNow;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);


        }
        public IResult Update(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carImage.CarId), CheckIfCarImageNull(carImage), SetDateTime(carImage));

            if (result != null)
            { return new ErrorResult("sdfsd"); }
            // carImage.Date = dateNow;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);




        }
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), true, Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), true, Messages.Listed);
        }



        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimited);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImageNull(CarImage carImage)
        {
            if (carImage.ImagePath == null)
                carImage.ImagePath = @"C:\Users\Fatih\source\repos\ReCapProject\WepAPI\CarImages\defaultImage.png";
            return new SuccessResult();
        }

        private IResult SetDateTime(CarImage carImage)
        {
            carImage.Date = dateNow;
            return new SuccessResult();
        }
    }
}
