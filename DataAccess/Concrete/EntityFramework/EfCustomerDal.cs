using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {

      

        public List<CustomerDetailsDto> getCustomerDetails(Expression<Func<Customer, bool>> filter=null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from customer in filter is null? context.Customers: context.Customers.Where(filter)
                    join user in context.Users
                        on customer.UserId equals user.Id
                    select new CustomerDetailsDto
                    {
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserId = user.Id,
                        CustomerId = customer.UserId,
                        Status = user.Status
                    };
                return result.ToList();
            }
        }

        
    }
}
