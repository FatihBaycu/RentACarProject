using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserProfilePictureService _userProfilePictureService;
        private ICustomerService _iCustomerService;
        private IResetPasswordCodeService _resetPasswordCodeService;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICustomerService _customerService, IUserProfilePictureService userProfilePictureService, IResetPasswordCodeService resetPasswordCodeService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _iCustomerService = _customerService;
            _userProfilePictureService = userProfilePictureService;
            _resetPasswordCodeService = resetPasswordCodeService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            var customer = new Customer
            {
                UserId = user.Id,
                CompanyName = "A",
                CustomerFindexPoint = 100
            };
            _iCustomerService.Add(customer);

            var userProfilePicture = new UserProfilePicture
            {
                UserId = user.Id,
                PicturePath = "Uploads/Images/CarImages/defaultProfilePicture.png"

            };
            _userProfilePictureService.AddWithoutPicture(userProfilePicture);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, true, Messages.SuccessfulLogin);
        }

        public IDataResult<UserForUpdateDto> Update(UserForUpdateDto userForUpdate)
        {
            var currentCustomer = _userService.GetById(userForUpdate.UserId);

            var user = new User
            {
                Id = userForUpdate.UserId,
                Email = userForUpdate.Email,
                FirstName = userForUpdate.FirstName,
                LastName = userForUpdate.LastName,

            };

            _userService.Update(user);

            var customer = new Customer
            {
                CustomerId = userForUpdate.Id,
                UserId = userForUpdate.UserId,
                CompanyName = userForUpdate.CompanyName
            };

            _iCustomerService.Update(customer);

            return new SuccessDataResult<UserForUpdateDto>(userForUpdate, "Müşteri Güncellendi.");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = _userService.GetById(changePasswordDto.UserId).Data;
            if (userToCheck == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(changePasswordDto.OldPassword, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.PasswordHash = passwordHash;
            userToCheck.PasswordSalt = passwordSalt;
            _userService.Update(userToCheck);
            return new SuccessResult("Parola Değişti.");
        }

        public IResult PasswordReset(PasswordResetDto passwordResetDto)
        {

            _resetPasswordCodeService.ConfirmResetCode(passwordResetDto.Code);
           var resetPassword= _resetPasswordCodeService.GetByCode(passwordResetDto.Code);
            resetPassword.Data.IsActive = false;

            byte[] passwordHash, passwordSalt;
            var userToCheck = _userService.GetById(passwordResetDto.UserId).Data;
            if (userToCheck == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            HashingHelper.CreatePasswordHash(passwordResetDto.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.PasswordHash = passwordHash;
            userToCheck.PasswordSalt = passwordSalt;
            _userService.Update(userToCheck);
            _resetPasswordCodeService.Update(resetPassword.Data);
            return new SuccessResult("Parola Değişti.");
        }
        

        
    }
}