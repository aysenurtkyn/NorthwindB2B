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
    public  interface IProductService
    {
        public IDataResult<List<Product>> GetAll();
       public IDataResult<List<Product>>  GetAllByCategoryId(int id);
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDTo>> GetProductDetails();
        IResult Add(Product product);
       IDataResult<Product> GetById(int productId);

    }
}
