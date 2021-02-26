using System;
using System.Collections.Generic;
using System.Text;
using Core.Results;
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

    }
}
