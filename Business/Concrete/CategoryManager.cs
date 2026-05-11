using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }

        public IResult Add(Category category)
        {
            var categoryName = _categoryDal.Get(c => c.CategoryName == category.CategoryName);
            if(categoryName != null)
            {
                return new ErrorResult(Messages.AlreadyExist);
            }
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IDataResult<List<Category>> GetAll()
        {
           if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Category>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<List<Category>> GetById(int CategoryId)
        {
            var categoryId = _categoryDal.GetAll(c => c.CategoryId == CategoryId);
            if (categoryId != null)
            {
                return new ErrorDataResult<List<Category>>(Messages.NotAvailable);
            }
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c => c.CategoryId == CategoryId));
        }

        public IDataResult<List<CategoryDetailDTO>> GetCategoryDetail()
        {
            if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CategoryDetailDTO>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CategoryDetailDTO>>(_categoryDal.GetCategoryDetails());
        }
    }
}
