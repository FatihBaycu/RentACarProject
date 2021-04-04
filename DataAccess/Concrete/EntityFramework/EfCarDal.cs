using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {


        public List<CarDetailsDto> getCarDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                    join b in context.Brands on ca.BrandId equals b.BrandId
                    join co in context.Colors on ca.ColorId equals co.ColorId
                    select new CarDetailsDto
                        { CarName = ca.CarName, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = ca.DailyPrice,CarId = ca.Id,ModelYear = ca.ModelYear,BrandId = ca.BrandId,CarFindexPoint = ca.CarFindexPoint};

                return result.ToList();
            }


            //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
            //    {
            //        using (RentACarContext context = new RentACarContext())
            //        {
            //            return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            //        }
            //    }

            //    public Car Get(Expression<Func<Car, bool>> filter)
            //    {
            //        using (RentACarContext context = new RentACarContext())
            //        {
            //            return context.Set<Car>().SingleOrDefault(filter);
            //        }
            //    }

            //    public void Add(Car entity)
            //    {
            //        using (RentACarContext context = new RentACarContext())
            //        {
            //            var addedEntity = context.Entry(entity);
            //            addedEntity.State = EntityState.Added;
            //            context.SaveChanges();
            //        }
            //    }

            //    public void Update(Car entity)
            //    {
            //        using (RentACarContext context = new RentACarContext())
            //        {
            //            var updatedEntity = context.Entry(entity);
            //            updatedEntity.State = EntityState.Modified;

            //            context.SaveChanges();
            //        }
            //    }

            //    public void Delete(Car entity)
            //    {
            //        using (RentACarContext context=new RentACarContext())
            //        {
            //            var deletedEntity = context.Entry(entity);
            //            deletedEntity.State = EntityState.Deleted;
            //            Console.WriteLine(entity.Id+" Kayıtlı Id Verisi Silindi");
            //            context.SaveChanges();
            //        }
            //    }

            //    public List<Car> GetCarsByBrandId(int brandId)
            //    {
            //        using (RentACarContext context = new RentACarContext())
            //        {
            //            return context.Cars.Where(p => p.BrandId == brandId).ToList();
            //        }
            //    }

            //    public List<Car> GetCarsByColorId(int colorId)
            //    {
            //        using (RentACarContext context = new RentACarContext())
            //        {
            //            return context.Cars.Where(p => p.ColorId == colorId).ToList();
            //        }
            //    }
            //public List<Car> GetCarsByBrandId(int brandId)
            //{
            //    throw new NotImplementedException();
            //}

            //public List<Car> GetCarsByColorId(int colorId)
            //{
            //    throw new NotImplementedException();
            //}


            //CarName, BrandName, ColorName, DailyPrice
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
                        ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()
                    };

                return result.ToList();
            }
        }

        public CarDetailsDto GetCarDetailsById(Expression<Func<Car, bool>> filter)
        {
            using(RentACarContext context = new RentACarContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
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
                        ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()
                    };

                return result.FirstOrDefault();
            }
        }
    }
}
