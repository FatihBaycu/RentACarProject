using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserForUpdateDto:UserForRegisterDto,IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
