using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalsDetailsDto> getRentalsDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from re in context.Rentals
                             join c in context.Customers on re.CustomerId equals c.CustomerId
                             join us in context.Users on c.CustomerId equals us.Id
                             join cars in context.Cars on re.CarId equals cars.BrandId
                             select new RentalsDetailsDto
                             { CarName = cars.CarName, CompanyName = c.CompanyName, FirstName = us.FirstName, LastName = us.LastName };
                return result.ToList();
            }


        }
    }
}

