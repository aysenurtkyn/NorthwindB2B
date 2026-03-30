using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCustomerDal : EfEntityReBase<Customer, NortwindContext>, ICustomerDal
    {
        public List<CustomerDetailDTO> GetCustomerDetails()
        {
           using (NortwindContext context = new NortwindContext())
            {
                var result = from c in context.Customers
                             join o in context.Orders
                             on c.CustomerId equals o.CustomerId into customerOrders
                             select new CustomerDetailDTO
                             {
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName,
                                 City = c.City,
                                 OrderCount = customerOrders.Count()
                             };
               return result.ToList();

            }
        }
    }
}
