using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace webapp_travel_agency.Models
{
    public class Info
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il titolo è obbligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Devi inserire un messaggio")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Inserisci il tuo nome")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Inserisci una email valida")]
        public string CustomerEmail { get; set; }

        public DateTime Created { get; set; }

        public int? PacchettoViaggioId { get; set; }

        [AllowNull]
        public PacchettoViaggio? PacchettoViaggio { get; set; }


        public Info()
        {
            this.Created = DateTime.Now;
        }
    }
}
