using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private ICardService _iCardService;

        public CardsController(ICardService iCardService)
        {
            _iCardService = iCardService;
        }

        [HttpGet("getall")]
       public IActionResult GetAll()
       {
           var result = _iCardService.GetAll();
           if (result.Success)
           {
               return Ok(result);
           }
           else
           {
               return BadRequest(result);
           }
        }
       [HttpPost("addcard")]
        public IActionResult AddCard(Card card)
       {
           var result = _iCardService.Add(card);
           return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
       }
       [HttpPut("updatecard")]
       public IActionResult UpdateCard(Card card)
        {
           var result = _iCardService.Update(card);
           return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
       }

       [HttpPost("deletecard")]
       public IActionResult DeleteCard(Card card)
        {
           var result = _iCardService.Delete(card);
           return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
       }

       [HttpGet("getcardbyid")]
       public IActionResult GetCardById(int cardId)
       {
           var result = _iCardService.GetById(cardId);
           if (result.Success)
           {
               return Ok(result);
           }
           else
           {
               return BadRequest(result);
           }

       }

       [HttpGet("getcardsbycustomerid")]
       public IActionResult GetCardsByCustomerId(int customerId)
       {
           var result = _iCardService.GetCardByCustomerId(customerId);
           
           if (result.Success)
           {
               return Ok(result);
           }
           else
           {
               return BadRequest(result);
           }
       }
    }
}
