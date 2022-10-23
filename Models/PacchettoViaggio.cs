using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        public int Id { get; set; }

        public string? Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public DateTime Date { get; set; }


        public List<Info>? Messages { get; set; }

        public PacchettoViaggio()
        {

        }

    }
}
