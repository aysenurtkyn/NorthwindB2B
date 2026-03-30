using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerDetailDTO: IDTo
    {
        public string CustomerId { get; set; } 
        public string CompanyName { get; set; }
        public string City { get; set; }
        public int OrderCount { get; set; }
    }
}
