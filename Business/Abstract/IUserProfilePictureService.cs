using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUserProfilePictureService
    {
        IDataResult<UserProfilePicture> GetUserImageById(int userId);
        IResult Add(UserProfilePicture userProfilePicture, IFormFile file);
        IResult AddWithoutPicture(UserProfilePicture userProfilePicture);
        IResult Delete(UserProfilePicture userProfilePicture);
        IResult Update(UserProfilePicture userProfilePicture, IFormFile file);
        IDataResult<List<UserProfilePicture>> GetAll();
        IDataResult<UserProfilePicture> GetById(int userPictureId);
    }
}