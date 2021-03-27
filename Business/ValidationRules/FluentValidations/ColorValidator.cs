using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidations
{
   public  class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).MinimumLength(1);
            //RuleFor(p => p.ColorName).Must(p => p.StartsWith("a"));
        }
    }
}
