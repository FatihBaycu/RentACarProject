using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
  public interface IColorService
    {

        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
        List <Color> GetAll();
        List <Color> GetByColorId(int colorId); 




    }
}
