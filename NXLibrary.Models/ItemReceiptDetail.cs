using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemReceiptDetail
    {
        public int Id { get; set; }
        public int ItemReceiptId { get; set; }
        public int BookId { get; set; }
        public int QTY { get; set; }
        public double Price { get; set; }
        public ItemReceipt ItemReceipt { get; set; } = default!;
        public Book Book { get; set; } = default!;
    }
}
