using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Models.NXLibraryEnums;

namespace Models
{
    public class PODetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(PONumberId))]
        public PONumber? PONumber { get; set; }
        public int? PONumberId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }
        public int? BookId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

    }
}