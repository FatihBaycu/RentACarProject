using Microsoft.AspNetCore.Http;
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
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        // public IActionResult Add([FromForm] CarImage carImage, [FromForm(Name = "Image")] IFormFile file)
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            var result = _carImageService.Add(carImage, file);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm(Name = "Image")] IFormFile file)
        {
            var result = _carImageService.Update(carImage, file);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


        [HttpGet("getbycarid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetCarImageByCarId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }




        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{

        //    var result = _carImageService.GetAll();
        //    return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
        //}
        //public DateTime date;

        //[HttpPost("add")]
        //public IActionResult Add(CarImage carImage)
        //{
        //    var result = _carImageService.Add(carImage);
        //    return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
        //}

        //[HttpPost("update")]
        //public IActionResult Update(CarImage carImage)
        //{
        //    var result = _carImageService.Update(carImage);
        //    return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        //}
        //[HttpPost("delete")]
        //public IActionResult Delete(CarImage carImage)
        //{
        //    var result = _carImageService.Delete(carImage);
        //    return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        //}
        //[HttpGet("getcarimagesbycarid")]
        //public IActionResult GetCarImageByCarId(int id)
        //{
        //    var result = _carImageService.GetCarImageByCarId(id);
        //    return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        //}
    }
}
