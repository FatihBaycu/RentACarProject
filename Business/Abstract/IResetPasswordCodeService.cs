using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface IResetPasswordCodeService
   {
        IResult Add(ResetPasswordCode resetPasswordCode);
        IResult Update(ResetPasswordCode resetPasswordCode);
        IResult Delete(ResetPasswordCode resetPasswordCode);
        IDataResult<List<ResetPasswordCode>> GetAll();
        IDataResult<ResetPasswordCode> GetById(int resetCodeID);
        IDataResult<ResetPasswordCode> GetByCode(string resetCode);
        IDataResult<ResetPasswordCode> GetByUserId(int userId);
        IResult ConfirmResetCode(string code);
        IResult ConfirmResetCodeWithUserId(ConfirmPasswordResetDto confirmPasswordResetDto);
        

    }
}
