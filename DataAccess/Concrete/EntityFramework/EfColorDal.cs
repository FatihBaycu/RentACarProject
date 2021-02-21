using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:IColorDal
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
