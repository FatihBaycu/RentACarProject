using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalsByCustomerDto:IDto
    {
        public int  CustomerId { get; set; }
        public int  UserId { get; set; }
        public int  BrandId { get; set; }
        public int  ColorId { get; set; }
        public int  CarId { get; set; }
        public int RentalId { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  BrandName { get; set; }
        public string  ColorName { get; set; }
        public string  CarName { get; set; }
        public DateTime  RentDate { get; set; }
        public DateTime  ReturnDate { get; set; }
       
    }
}
