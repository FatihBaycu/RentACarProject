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
                        { CarName = ca.CarName, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = ca.DailyPrice };

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
    }
}
