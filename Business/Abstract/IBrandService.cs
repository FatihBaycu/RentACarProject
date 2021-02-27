﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IBrandService
   {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetById(int brandId);
    }
}
