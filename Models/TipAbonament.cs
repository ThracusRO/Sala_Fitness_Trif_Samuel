using System.ComponentModel.DataAnnotations;

namespace Sala_Fitness_Trif_Samuel.Models
{
    public class TipAbonament
    {
        public int ID { get; set; }  // Cheia primara

        [Required(ErrorMessage = "Denumirea este obligatorie.")]
        [RegularExpression("Bronze|Silver|Gold|Platinum|VIP", ErrorMessage = "Denumirea trebuie sa fie 'Bronze', 'Silver','Gold', 'Platinum', 'VIP'.")]
        public string Denumire { get; set; }  // Numele tipului de abonament (Gold, Silver, Bronze..)
    }
}
