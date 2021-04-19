using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
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

        public List<RentalsDetailsDtoTwo> getRentalsDetailsDtoTwo()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join cst in context.Customers on rental.CustomerId equals cst.CustomerId
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join user in context.Users on cst.UserId equals user.Id
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new RentalsDetailsDtoTwo()
                             {
                                 BrandName = brand.BrandName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 CompanyName = cst.CompanyName,
                                 CarDesctiption = car.Description,
                                 RentalId = rental.Id
                             };
                return result.ToList();

            }
        }

        public List<RentalsByCustomerDto> getRentalsByCustomerIdDto(Expression<Func<Rental, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            { 
                var result = from rental in filter is null ? context.Rentals : context.Rentals.Where(filter)
                    join customer in context.Customers on rental.CustomerId equals customer.CustomerId

                    join user in context.Users on customer.UserId equals user.Id
                    join car in context.Cars on rental.CarId equals car.Id
                    join color in context.Colors on car.ColorId equals color.ColorId
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    select new RentalsByCustomerDto()
                    {
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        CarName = car.CarName,
                        RentalId = rental.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };
                return result.ToList();

            }
        }

        //public List<RentalsDetailsDtoTwo> getRentalsDetailsTwo()
        //{


        //}
    }
}

