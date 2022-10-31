﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfResetPasswordCodeDal : EfEntityRepositoryBase<ResetPasswordCode, RentACarContext>, IResetPasswordCodeDal
    {
        
    }
}
