using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DTOs
{
    public class AddPurchaseOrderDetailDTO
    {
        public int? VendorId { get; set; }
        public int? BookId { get; set; }
        public int? QTY { get; set; }
        public double? Price { get; set; }

    }
}
