using System.ComponentModel.DataAnnotations;

namespace SeriesListWeb.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public bool Watch { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
