using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UpdatePurchaseOrderDTO
    {
        public int? Id { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? QTY { get; set; }

    }
}
