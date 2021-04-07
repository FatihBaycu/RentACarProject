﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success) { return Ok(result); }
            else { return (IActionResult)BadRequest(result); }
        }

        [HttpGet("rentalstwo")]
        public IActionResult RentalsDetailTwo()
        {
            var result = _rentalService.getRentalsDetailsDtoTwo();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }


        }


        [HttpPost("addrental")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPut("updaterental")]
        public IActionResult UpdateRental(Rental rental)
        {
            var result = _rentalService.Update(rental);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("deleterental")]
        public IActionResult DeleteRental(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }


        [HttpGet("getrentalsbycarid")]
        public IActionResult GetRentalByCarId(int carId)
        {
            var result = _rentalService.GetRentalByCarId(carId);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpGet("getrentalbyid")]
        public IActionResult GetRentalById(int rentalId)
        {
            var result = _rentalService.GetById(rentalId);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        //[HttpGet("getrentalsbycustomer")]
        //public IActionResult GetRentalsByCustomerId(int customerId)
        //{
        //    var result;
        //}
    }
}
