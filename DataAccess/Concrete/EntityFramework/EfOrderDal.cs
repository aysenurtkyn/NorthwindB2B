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
    public class EfOrderDal : EfEntityReBase<Order, NorthwindContext>, IOrderDal
    {
        public List<OrderDetailDTO> GetOrderDetails()
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                var result = from O in context.Orders
                             select new OrderDetailDTO
                             {
                                 OrderId = O.OrderId,
                                 ShipName = O.ShipName,
                                 OrderDate = O.OrderDate,

                             };
                return result.ToList();
            }
        }
    }
}
