using System.ComponentModel.DataAnnotations;
using static NXLibrary.Models.NXLibraryEnums;

namespace NXCarLot.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; } = "";
        public string? Author { get; set; } = "";
        public Genere? Genere { get; set; }
    }
}