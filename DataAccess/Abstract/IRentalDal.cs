﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
  public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalsDetailsDto> getRentalsDetail();
        List<RentalsDetailsDtoTwo> getRentalsDetailsDtoTwo();
        List<RentalsByCustomerDto> getRentalsByCustomerIdDto(Expression<Func<Rental, bool>> filter);

    }
}
