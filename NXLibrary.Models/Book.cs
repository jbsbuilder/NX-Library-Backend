using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Models.NXLibraryEnums;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; } = "";
        [ForeignKey(nameof(AuthorId))]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        public Genre? Genre { get; set; }
        public Double DeafaultPrice { get; set; }
    }
}