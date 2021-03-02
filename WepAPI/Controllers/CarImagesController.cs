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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var result = _carImageService.GetAll();
            return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
        }
        public DateTime date;

        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {
            var result = _carImageService.Add(carImage);
            return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpGet("getcarimagesbycarid")]
        public IActionResult GetCarImageByCarId(int id)
        {
            var result = _carImageService.GetCarImageByCarId(id);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
    }
}
