using Core.Entities.Concrate;
using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.ValidationRules.FluentValidation
{
    public  class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            
            //RuleFor(u => u.Password.Length > 6);

        }
    }
}
