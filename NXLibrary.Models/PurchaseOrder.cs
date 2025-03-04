using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime PODate { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; } = default!;
    }
}
