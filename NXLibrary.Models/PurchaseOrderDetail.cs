using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;
using static Models.NXLibraryEnums;

namespace Models
{
    public class PurchaseOrderDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        [ForeignKey(nameof(BookId))]
        public int? BookId { get; set; }
        public Book? Book { get; set; }
        public int? QTY { get; set; }
        public double? Price { get; set; }
        [NotMapped]
        public double? Subtotal { get {
                return QTY * Price;
            } }

    }
}