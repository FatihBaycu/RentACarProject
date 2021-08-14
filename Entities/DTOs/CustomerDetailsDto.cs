using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters;
using Core.Entities;

namespace Entities.DTOs
{
   public class CustomerDetailsDto:IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string  CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       // public byte[] PasswordSalt { get; set; }
        //public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public int CustomerFindexPoint { get; set; }
    }
}
