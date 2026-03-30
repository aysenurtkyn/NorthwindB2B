using Business.Abstract;
using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            // CategoryDetails();

            // CustomerOrders();

           // OrderDetails();

        }

        private static void OrderDetails()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            var result1 = orderManager.GetOrderDetails();
            foreach (var order in result1.Data)
            {
                Console.WriteLine(order.ShipName + ' ' + order.OrderDate);
            }
        }

        private static void CustomerOrders()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetails();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName + "' in sipariş sayısı = " + customer.OrderCount);
            }
        }

        private static void CategoryDetails()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result = categoryManager.GetCategoryDetail();
            foreach (var category in result.Data)
            {
                Console.WriteLine(category.CategoryName + '=' + category.ProductCount);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManagger = new ProductManager(new EfProductDal());

            var result = productManagger.GetProductDetails();
            if(result.Success== true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + '/' + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
