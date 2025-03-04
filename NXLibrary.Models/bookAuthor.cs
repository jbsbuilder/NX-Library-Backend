using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class BookAuthor
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } = "";

        public ICollection<Book> Book { get; } = new List<Book>();
    }
}
