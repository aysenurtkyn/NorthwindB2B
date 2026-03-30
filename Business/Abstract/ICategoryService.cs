using Core.Utilities;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public IDataResult<List<Category>> GetAll();
        public IDataResult<List<Category>> GetById(int CategoryId);
        public IDataResult<List<CategoryDetailDTO>> GetCategoryDetail();
        IResult Add(Category category);


    }
}
