using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfiePicturesController : Controller
    {

        private IUserProfilePictureService _userProfilePictureService;

        public UserProfiePicturesController(IUserProfilePictureService userProfilePictureService)
        {
            _userProfilePictureService = userProfilePictureService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userProfilePictureService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        
   
        [HttpPost("add")]
        public IActionResult Add([FromForm] UserProfilePicture userProfilePicture, [FromForm(Name = "imagePath")] IFormFile file)
        {
            var result = _userProfilePictureService.Add(userProfilePicture, file);
            return result.Success ? Ok(result) : BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(UserProfilePicture userProfilePicture)
        {
            var result = _userProfilePictureService.Delete(userProfilePicture);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm] UserProfilePicture userProfilePicture, [FromForm(Name = "ImagePath")] IFormFile file)
        {
            var result = _userProfilePictureService.Update(userProfilePicture, file);
            return result.Success ? Ok(result) : BadRequest(result);

        }
        
    }
}