using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserProfilePictureManager:IUserProfilePictureService
    {

        private IUserProfilePictureDal _userProfilePictureDal;

        public UserProfilePictureManager(IUserProfilePictureDal userProfilePictureDal)
        {
            _userProfilePictureDal = userProfilePictureDal;
        }
        
        public IDataResult<UserProfilePicture> GetUserImageById(int userId)
        {
            return new SuccessDataResult<UserProfilePicture>(_userProfilePictureDal.Get(p => p.UserId == userId),
                Messages.Listed);
        }

        public IResult Add(UserProfilePicture userProfilePicture, IFormFile file)
        {
            var result = BusinessRules.Run(CheckUserPicture(userProfilePicture.UserId));

            if (result != null)
            {
                return result;
            }
            
            userProfilePicture.PicturePath = SaveImage(file);
            _userProfilePictureDal.Add(userProfilePicture);
            return new SuccessResult(Messages.Added);
        }   
        
        public IResult AddWithoutPicture(UserProfilePicture userProfilePicture)
        {
            var result = BusinessRules.Run(CheckUserPicture(userProfilePicture.UserId));

            if (result != null)
            {
                return result;
            }
            
            _userProfilePictureDal.Add(userProfilePicture);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UserProfilePicture userProfilePicture)
        {
            DeleteImage(userProfilePicture.Id);
            _userProfilePictureDal.Delete(userProfilePicture);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(UserProfilePicture userProfilePicture, IFormFile file)
        {
            userProfilePicture.PicturePath = UpdateImage(userProfilePicture.Id, file);
            _userProfilePictureDal.Update(userProfilePicture);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<UserProfilePicture>> GetAll()
        {
            return new SuccessDataResult<List<UserProfilePicture>>(_userProfilePictureDal.GetAll());
        }

        public IDataResult<UserProfilePicture> GetById(int userPictureId)
        {
            return new SuccessDataResult<UserProfilePicture>(_userProfilePictureDal.Get(p => p.Id == userPictureId),
                Messages.Listed);
        }
        
        private string SaveImage(IFormFile file)
        {
            return FileHelperAsync.ImageSave(file).Result.ToString();
        }

        private void DeleteImage(int userPictureId)
        {
            var userPicture = _userProfilePictureDal.Get(c => c.Id == userPictureId);
            var path = userPicture.PicturePath;
 
            File.Delete(Directory.GetParent(Directory.GetCurrentDirectory()) + PathNames.BaseName + path);
        }

        private string UpdateImage(int userPictureId, IFormFile file)
        {
            DeleteImage(userPictureId);
            return SaveImage(file);
        }

        private IResult CheckUserPicture(int userId)
        {
            var result = _userProfilePictureDal.Get(p => p.UserId == userId);
            
            if (result!=null)
            {
                return new ErrorResult("Photo already exist.");
            }
            return new SuccessResult();
        }
    }
}