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
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.Listed);
        }

        public IResult Add(Rental rental)
        {
            //if (_rentalDal.Get(p => p.CarId == rental.CarId && p.RentDate == rental.RentDate) != null)
            //{
            //    return new ErrorResult("Araç Seçili Tarihlerde Kullanımda.");
            //}

            var result = BusinessRules.Run(WillLeasedCarAvailable(rental.CarId));
            _rentalDal.Add(rental);
            return new Result(true);
        }


        
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }


        
        
        public IDataResult<List<RentalsDetailsDto>> getRentalsDetail()
        {
            
            return new SuccessDataResult<List<RentalsDetailsDto>>(_rentalDal.getRentalsDetail(),true,Messages.Listed);
        }

        public IDataResult<List<RentalsDetailsDtoTwo>> getRentalsDetailsDtoTwo()
        {
            return new SuccessDataResult<List<RentalsDetailsDtoTwo>>(_rentalDal.getRentalsDetailsDtoTwo(), true, Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(p => p.Id == rentalId);
            return new SuccessDataResult<Rental>(result,true,Messages.Listed);
        }

        public IDataResult<List<Rental>> GetRentalByCarId(int carId)
        {
            var result = _rentalDal.GetAll(p => p.CarId == carId);
            return new SuccessDataResult<List<Rental>>(result);
        }


        private IResult WillLeasedCarAvailable(int carId)
        {
            if (_rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null) != null)
                return new ErrorResult(Messages.CarNotAvaible);
            else
                return new SuccessResult();
        }

        private IResult CanARentalCarBeReturned(int carId)
        {
            if (_rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null) == null)
                return new ErrorResult(Messages.CarNotAvaible);
            else
                return new SuccessResult();
        }

    }

}

