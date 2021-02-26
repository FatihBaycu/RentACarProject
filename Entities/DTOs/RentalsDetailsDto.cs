using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalsDetailsDto:IDto
    {
        public string CarName { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }

    }
}
