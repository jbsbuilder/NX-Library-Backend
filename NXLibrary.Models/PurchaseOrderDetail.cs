using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PurchaseOrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int BookId { get; set; }
        public int QTY { get; set; }
        public Double Price { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = default!;
        public Book Book { get; set; } = default!;

    }
}