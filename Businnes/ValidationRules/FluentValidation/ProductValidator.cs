using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.Name).MinimumLength(2);
            
        }
    }
}
