using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        //[Authorize(Roles="Cars.List")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }


        }

        [HttpPost("addcar")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("updatecar")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("deletecar")]
        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.Delete(car);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("getcardetail")]
        public IActionResult getCarDetail()
        {
            var result = _carService.getCarDetail();
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionTest(Car car)
        {
            var result = _carService.TransactionalOperation(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }


    }
}
