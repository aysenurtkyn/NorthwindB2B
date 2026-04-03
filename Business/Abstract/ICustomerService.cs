using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public IDataResult<List<Customer>> GetAll();
        public IDataResult<List<Customer>> GetById(string customerId);
        public IDataResult<List<CustomerDetailDTO>> GetCustomerDetails();
        IResult Add(Customer customer);




    }
}
