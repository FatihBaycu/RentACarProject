﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
   public class CarDetailsDto:IDto
    {
        
        public string Description { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImagePath { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int CarFindexPoint { get; set; }
        
    }
}
