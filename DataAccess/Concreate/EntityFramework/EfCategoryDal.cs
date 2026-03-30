using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCategoryDal : EfEntityReBase<Category, NortwindContext>, ICategoryDal
    {
        public List<CategoryDetailDTO> GetCategoryDetails()
        {
          using(NortwindContext context = new NortwindContext())
            {
                var result = from c in context.Categories
                             select new CategoryDetailDTO
                             {
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 ProductCount = context.Products.Count(p => p.CategoryId == c.CategoryId)

                             };
                return result.ToList();
            }
        }
    }
}
