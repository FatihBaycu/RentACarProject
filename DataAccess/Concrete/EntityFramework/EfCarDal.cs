using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        // private IMapper _iMapper;
        //
        // public EfCarDal(IMapper _mapper)
        // {
        //     _iMapper = _mapper;
        // }
        //
        public List<CarDetailsDto> getCarDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                    join b in context.Brands on ca.BrandId equals b.BrandId
                    join co in context.Colors on ca.ColorId equals co.ColorId
                    select new CarDetailsDto
                    {
                        CarName = ca.CarName, BrandName = b.BrandName, ColorName = co.ColorName,
                        DailyPrice = ca.DailyPrice, CarId = ca.Id, ModelYear = ca.ModelYear, BrandId = ca.BrandId,
                        CarFindexPoint = ca.CarFindexPoint
                    };

                return result.ToList();
            }
        }


        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
                        let image = (from carImage in context.CarImages where c.Id == carImage.CarId select carImage.ImagePath)
                    select new CarDetailsDto
                    {
                        CarId = c.Id,
                        BrandName = b.BrandName,
                        CarName = c.CarName,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice,
                        BrandId = c.BrandId,
                        ColorId = c.ColorId,
                        CarFindexPoint=c.CarFindexPoint,
                        ImagePath = image.Any() ? image.FirstOrDefault() : new CarImage { ImagePath = "Uploads/Images/CarImages/defaultImage.png" }.ImagePath
                    };
        
                return result.ToList();
            }
        }


        // public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        // {
        //     using (RentACarContext context = new RentACarContext())
        //     {
        //         IQueryable<Car> result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
        //             join b in context.Brands
        //                 on c.BrandId equals b.BrandId
        //             join co in context.Colors
        //                 on c.ColorId equals co.ColorId
        //             let image = (from carImage in context.CarImages
        //                 where c.Id == carImage.CarId
        //                 select carImage.ImagePath)
        //             select c;
        //         var result2 = result.ToList();
        //
        //
        //         return _iMapper.Map<List<Car>, List<CarDetailsDto>>(result2);
        //     }
        // }


        public CarDetailsDto GetCarDetailsById(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
                    let image = (from carImage in context.CarImages
                        where c.Id == carImage.CarId
                        select carImage.ImagePath)
                    select new CarDetailsDto
                    {
                        CarId = c.Id,
                        BrandName = b.BrandName,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice,
                        ColorId = c.ColorId,
                        BrandId = c.BrandId,
                        CarName = c.CarName,
                        CarFindexPoint = c.CarFindexPoint,
                        ImagePath = image.FirstOrDefault()
                    };

                return result.FirstOrDefault();
            }
        }
    }
}