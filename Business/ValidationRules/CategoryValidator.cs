using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty();
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Category En az 3 karakter olmalı.");
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(5).WithMessage("Tanım en az 5 karakter olmalı.");
        }
    }
}
