using static Models.NXLibraryEnums;

namespace DTOs
{
    public class AddBookDTO
    {
        public string? BookTitle { get; set; } = "";
        public int AuthorId { get; set; }
        public Genere? Genere { get; set; }
        public int Copies { get; set; }
        public Double UnitPrice { get; set; }
    }
}
