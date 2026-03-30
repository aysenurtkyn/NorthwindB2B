using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDetailDTO:IDTo
    {
        public int OrderId { get; set; }
        public string ShipName { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
