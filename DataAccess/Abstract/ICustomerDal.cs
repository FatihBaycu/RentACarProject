using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
   public interface ICustomerDal:IEntityRepository<Customer>
   {
        List<CustomerDetailsDto> getCustomerDetails(Expression<Func<Customer, bool>> filter=null);
        CustomerDetailsDto getCustomerDetailById(Expression<Func<Customer, bool>> filter);

        CustomerDetailsDto getCustomerByEmail(Expression<Func<CustomerDetailsDto, bool>> filter);
   }
}
