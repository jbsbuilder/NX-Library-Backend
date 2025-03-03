using static Models.NXLibraryEnums;

namespace DTOs
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; } = "";
        public int AuthorId { get; set; }
        public Genre? Genre { get; set; }
        public Double DefaultPrice { get; set; }
    }
}
