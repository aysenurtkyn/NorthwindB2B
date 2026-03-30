using Business.Abstract;
using Business.Constants;
using Core.Utilities;
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
    public class OrderManager : IOrderService
    {

        IOrderDal _orderDal;
        

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
          
        }
        public IResult Add(Order order)
        {
            if(order == null)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Order order)
        {
            var result= _orderDal.GetAll( o => o.OrderId == order.OrderId );
            if(result != null)
            {
                return new ErrorResult(Messages.InvalidData);
            }
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
           if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Order>>(Messages.MaintenanceTime);
            }
           return new SuccessDataResult<List<Order>>(_orderDal.GetAll() );
        }

        public IDataResult<Order> GetById(int orderId)
        {
            if(orderId < 0)
            {
                return new ErrorDataResult<Order>(Messages.InvalidId);
            }
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.OrderId == orderId));
        }

        public IDataResult<List<OrderDetailDTO>> GetOrderDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<OrderDetailDTO>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<OrderDetailDTO>>(_orderDal.GetOrderDetails());
        }

        public IResult Update(Order order)
        {
          var result = _orderDal.GetAll( o  => o.OrderId == order.OrderId );
            if(result == null)
            {
                return new ErrorResult(Messages.InvalidData);
            }
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
