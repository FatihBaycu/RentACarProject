﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            if (brand.BrandName.Length <= 0)
            {
                Console.WriteLine("Açıklama uzunluğu 2 harfden uzun olmalıdır.");
                return new ErrorResult(Messages.CarNotAdded);
            }

            else
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), true, Messages.Listed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new DataResult<Brand>(_brandDal.Get(p => p.BrandId == brandId), true, Messages.Listed);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}
