using System.ComponentModel.DataAnnotations;

namespace Sala_Fitness_Trif_Samuel.Models
{
    public class Specializare
    {
        public int ID { get; set; }  // Cheia primara

        [Required(ErrorMessage = "Denumirea este obligatorie.")]
        [StringLength(30, ErrorMessage = "Denumirea nu poate avea mai mult de 30 de caractere.")]
        public string Denumire { get; set; }  // Denumirea specializarii (Personal Trainer, Yoga, etc.)
    }
}
