using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookAuthor
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; } = "";

        public ICollection<Book> Book { get; set;} = new List<Book>();
    }
}
