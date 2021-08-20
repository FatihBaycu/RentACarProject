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
                    join userProfilePicture in context.UserProfilePictures on user.Id equals userProfilePicture.UserId
                             select new CustomerDetailsDto
                    {
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserId = user.Id,
                        CustomerId = customer.CustomerId,
                        Status = user.Status,
                        PicturePath = userProfilePicture.PicturePath.Length == 0 ? "Uploads/Images/CarImages/defaultProfilePicture.png" : userProfilePicture.PicturePath,
                        CustomerFindexPoint = (int)customer.CustomerFindexPoint
                    };
                return result.ToList();
            }
        }
        
        public CustomerDetailsDto getCustomerDetailById(Expression<Func<Customer, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from customer in filter is null ? context.Customers : context.Customers.Where(filter)
                    join user in context.Users
                        on customer.UserId equals user.Id
                     join userProfilePicture in context.UserProfilePictures on user.Id equals userProfilePicture.UserId

                             select new CustomerDetailsDto
                    {
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserId = user.Id,
                        CustomerId = customer.CustomerId,
                        PicturePath = userProfilePicture.PicturePath.Length==0? "Uploads/Images/CarImages/defaultProfilePicture.png" : userProfilePicture.PicturePath,
                        Status = user.Status,
                        CustomerFindexPoint = (int) customer.CustomerFindexPoint
                    };
                return result.FirstOrDefault();
            }
        }

       public CustomerDetailsDto getCustomerByEmail(Expression<Func<CustomerDetailsDto, bool>> filter)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from customer in context.Customers
                    join user in context.Users
                        on customer.UserId equals user.Id
                    join userProfilePicture in context.UserProfilePictures on user.Id equals userProfilePicture.UserId

                             select new CustomerDetailsDto
                    {
                        CustomerId = customer.CustomerId,
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PicturePath = userProfilePicture.PicturePath.Length == 0 ? "Uploads/Images/CarImages/defaultProfilePicture.png" : userProfilePicture.PicturePath,
                        CompanyName = customer.CompanyName,
                        CustomerFindexPoint = (int) customer.CustomerFindexPoint
                    };
                return result.SingleOrDefault(filter);
            }
        }

       
    }
}
