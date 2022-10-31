using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.ValidationRules.FluentValidations
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(p => p.EmailAddress).NotNull();
            RuleFor(p => p.EmailAddress).EmailAddress(EmailValidationMode.AspNetCoreCompatible);


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
