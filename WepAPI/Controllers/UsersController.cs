using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Business.Mail;
using Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _iUserService;
        private IMailService _mailService;
        private IResetPasswordCodeService _resetPasswordCodeService;

        public UsersController(IUserService ıUserService, IMailService mailService, IResetPasswordCodeService resetPasswordCodeService)
        {
            _iUserService = ıUserService;
            _mailService = mailService;
            _resetPasswordCodeService = resetPasswordCodeService;
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
        
        
        [HttpGet("get-user-by-email")]
        public IActionResult GetByEmail(string email)
        {
            var result = _iUserService.GetUserByEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }



        [HttpPost("send-password-reset-mail")]
        public IActionResult SendEmail(String email)
        {
            Email newEmail = new Email();
            newEmail.EmailAddress = email;
         
            var result= _mailService.SendPasswordResetMailAsync(newEmail);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPost("confirm-password-reset-code")]
        public IActionResult ConfirmPasswordResetCode(ConfirmPasswordResetDto confirmPasswordResetDto)
        {                   
            var result= _resetPasswordCodeService.ConfirmResetCodeWithUserId(confirmPasswordResetDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }


       
    }
}
