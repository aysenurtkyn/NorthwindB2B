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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if(customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            return new SuccessResult(Messages.CustomerAdded);
          
         }

        public IDataResult<List<Customer>> GetAll()
        {
           if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetById(string customerId)
        {
           if(!int.TryParse(customerId, out int parsedId) || parsedId < 0)
            {
                return new ErrorDataResult<List<Customer>>(Messages.InvalidId);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.CustomerId == customerId));
        }

        public IDataResult<List<CustomerDetailDTO>> GetCustomerDetails()
        {
            if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CustomerDetailDTO>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CustomerDetailDTO>>(_customerDal.GetCustomerDetails());
          
        }
    }
}
