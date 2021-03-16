using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalsDetailsDtoTwo : IDto
    {
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
