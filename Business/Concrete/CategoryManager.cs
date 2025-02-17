using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        IResult ICategoryService.Add(Category entity)
        {
            var validator = new CategoryValidator();
            ValidationResult validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                string errorMessages = string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage));
                return new ErrorResult(errorMessages);
            }
            _categoryDal.Add(entity);
            return new SuccessResult(Messages.CategoryAdded);
        }

        IDataResult<List<Category>> ICategoryService.GetAll()
        {
            var dataResult = new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
            return dataResult;
        }
    }
}
