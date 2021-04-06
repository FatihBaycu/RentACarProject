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
        private IUserService _iUserService;

        public UsersController(IUserService ıUserService)
        {
            _iUserService = ıUserService;
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
            var result = _iUserService.Add(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _iUserService.Update(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("deleteuser")]
        public IActionResult DeleteUser(User user)
        {
            var result = _iUserService.Delete(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPut("updateinfos")]
        public IActionResult UpdateInfos(User user)
        {
            var result = _iUserService.UpdateInfos(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _iUserService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
