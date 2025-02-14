using System.ComponentModel.DataAnnotations;
using static Models.NXLibraryEnums;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? bookTitle { get; set; } = "";
        public string? bookAuthor { get; set; } = "";
        public Genere? Genere { get; set; }
        public int Copies { get; set; }
    }
}