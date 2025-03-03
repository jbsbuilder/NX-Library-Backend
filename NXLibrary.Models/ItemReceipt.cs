using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemReceipt
    {
        [Key]
        public int Id { get; set; }
        public DateTime IRDate { get; set; }
        public int PurchaseOrderId { get; set; }
        public int VendorId {get; set;}

        public Vendor Vendor { get; set; } = default!;
        //public PurchaseOrder PurchaseOrder { get; set; } = default!;

    }
}
