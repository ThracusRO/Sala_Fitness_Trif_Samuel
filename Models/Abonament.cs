using System.ComponentModel.DataAnnotations;

namespace Sala_Fitness_Trif_Samuel.Models
{
    public class Abonament
    {
        public int ID { get; set; }  // Cheia primara

        public int? TipAbonamentID { get; set; }  // ID-ul tipului de abonament (optional)
        public TipAbonament? TipAbonament { get; set; }  // Navigare catre TipAbonament
        [Required(ErrorMessage = "Pretul este obligatoriu.")]
        [Range(50, 1000, ErrorMessage = "Pretul trebuie sa fie intre 50 si 2000 RON.")]
        public int? Pret { get; set; }  // Pretul abonamentului (int, optional)
        
        [Required(ErrorMessage = "Durata este obligatorie.")]
        [RegularExpression("Lunar|Trimestrial|Semestrial|Anual", ErrorMessage = "Durata trebuie sa fie 'Lunar', 'Trimestrial', 'Semestrial' sau 'Anual'.")]
        public string Durata { get; set; }  // Durata abonamentului (ex: "Lunar", "Trimestrial")
    }
}
