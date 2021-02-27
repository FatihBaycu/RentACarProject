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
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            return result.Success ? (IActionResult)BadRequest(result) : Ok(result);
        }

        [HttpPost("addcolor")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Add(color);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("updatecolor")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("deletecolor")]
        public IActionResult DeleteColor(Color color)
        {
            var result = _colorService.Delete(color);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

    }
}
