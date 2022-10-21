using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Info
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        public DateTime Created { get; set; }

        public int? PacchettoViaggioId { get; set; }
        public PacchettoViaggio? PacchettoViaggio { get; set; }


        public Info()
        {
            this.Created = DateTime.Now;
        }
    }
}
