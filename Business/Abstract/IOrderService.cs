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
    public interface IOrderService
    {

        public IDataResult<List<Order>> GetAll();
        IDataResult<List<OrderDetailDTO>> GetOrderDetails();
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);    
        IDataResult<Order> GetById(int orderId);




    }
}
