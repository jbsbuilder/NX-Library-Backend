using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UpdatePODTO
    {
        public int Id { get; set; }
        public int? PONumberId { get; set; }
        public int? VendorId { get; set; }
        public int? BookId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
