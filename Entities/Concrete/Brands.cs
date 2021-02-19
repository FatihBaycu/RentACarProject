using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
   public class Brands:IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }


    }
}
