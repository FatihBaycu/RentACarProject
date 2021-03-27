using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidations
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            //RuleFor(p => p.RentDate);
        }
    }
}
