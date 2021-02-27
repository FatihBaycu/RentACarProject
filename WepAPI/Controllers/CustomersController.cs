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
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            return result.Success ? (IActionResult)BadRequest(result) : Ok(result);
        }

        [HttpPost("addcustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.Add(customer);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("updatecustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.Update(customer);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("deletecustomer")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            var result = _customerService.Delete(customer);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

    }
}
