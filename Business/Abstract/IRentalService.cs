using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
 public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalsDetailsDto>> getRentalsDetail();
        IDataResult<List<RentalsDetailsDtoTwo>> getRentalsDetailsDtoTwo();


        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<Rental>> GetRentalByCarId(int carId);



    }
}
