using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.InMemory
{
  
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 2, ProductName = "Computer", UnitPrice = 25000 ,UnitsInStock= 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Mouse", UnitPrice = 2500 ,UnitsInStock= 1466 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Keyboard", UnitPrice = 1300 , UnitsInStock= 34},
                new Product { ProductId = 4, CategoryId = 1, ProductName = "Adapter", UnitPrice = 4000 , UnitsInStock= 105},
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Laptop", UnitPrice = 4050, UnitsInStock= 150 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;

            //foreach(Product p in _products)
            //{
            //    if(p.ProductId == product.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            // LINQ (Language Inregrate Query )
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = null;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

       

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDTo> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }

}
