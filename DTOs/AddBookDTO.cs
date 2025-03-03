using static Models.NXLibraryEnums;

namespace DTOs
{
    public class AddBookDTO
    {
        public string? Title { get; set; } = "";
        public int AuthorId { get; set; }
        public Genre? Genre { get; set; }
        public Double DefaultPrice { get; set; }
    }
}
