using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ResetPasswordCode:IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int UserId { get; set; }
        public string UserEmail{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

    }
}
