﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), true, Messages.Listed);
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CustomerDetailsDto>> getCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.getCustomerDetails(), true, Messages.Listed);
           
        }

        public IDataResult<CustomerDetailsDto> getCustomerDetailById(int customerId)
        {
            return new SuccessDataResult<CustomerDetailsDto>(_customerDal.getCustomerDetailById(p => p.CustomerId == customerId));
        }

        public IDataResult<CustomerDetailsDto> getCustomerByEmail(string email)
        {
            return new SuccessDataResult<CustomerDetailsDto>(_customerDal.getCustomerByEmail(p => p.Email == email));
        }

        public IDataResult<Customer> getById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == customerId));
        }
    }
}
