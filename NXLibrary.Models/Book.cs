using System.ComponentModel.DataAnnotations;
using static Models.NXLibraryEnums;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? BookTitle { get; set; } = "";
       public int AuthorId { get; set; }
        public Genere? Genere { get; set; }
        public int Copies { get; set; }

        public BookAuthor? BookAuthor { get; set; }
    }
}