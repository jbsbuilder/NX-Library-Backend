using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DTOs
{
    public class AddPODTO
    {
        public int? VendorId { get; set; }
        public int? BookId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

    }
}
