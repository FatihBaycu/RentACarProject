using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
   public interface IUserService
   {
     //  IDataResult<List<User>> GetAll();
       IResult Add(User user);
       IResult Update(User user);
       IResult Delete(User user);
       IResult UpdateInfos(User user);

        List<OperationClaim> GetClaims(User user);
       IDataResult<User> GetUserByEmail(string email);
       
       User GetByMail(string email);
       IDataResult<User> GetById(int id);

       // IResult AddProfilePicture(int id,IFormFile file);

       //IDataResult<List<User>> GetCarsByBrandId(int brandId);
       //IDataResult<List<User>> GetCarsByColorId(int colorId);
       //IDataResult<List<CarDetailsDto>> getCarDetail();
   }
}
