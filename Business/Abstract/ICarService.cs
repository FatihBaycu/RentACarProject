using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    interface ICarService
    {
        List<Car> GetAll();

    }
}
