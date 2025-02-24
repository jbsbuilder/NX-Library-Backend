using System.ComponentModel.DataAnnotations;
using static Models.NXLibraryEnums;

namespace Models
{
    public class PODetail
    {
        [Key]
        public int Id { get; set; }
        public PONumber? PONumber { get; set; }
        public Book? Book { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

    }
}