using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _ıUserService;

        public UsersController(IUserService ıUserService)
        {
            _ıUserService = ıUserService;
        }


        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var result = _ıUserService.GetAll();
        //    return result.Success ? (IActionResult)BadRequest(result) : Ok(result);
        //}

        [HttpPost("adduser")]
        public IActionResult AddUser(User user)
        {
            var result = _ıUserService.Add(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPut("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _ıUserService.Update(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("deleteuser")]
        public IActionResult DeleteUser(User user)
        {
            var result = _ıUserService.Delete(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
    }
}
