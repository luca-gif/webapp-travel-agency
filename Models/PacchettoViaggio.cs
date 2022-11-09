using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        public int Id { get; set; }

        public string? Image { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Inserisci una descrizione")]
        public string Description { get; set; }
        [Range(1, 10000, ErrorMessage = "Inserisci un valore compreso tra {1} e {2}")]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public List<Info>? Messages { get; set; }

        public PacchettoViaggio()
        {

        }

    }
}
