using System.ComponentModel.DataAnnotations;

namespace Sala_Fitness_Trif_Samuel.Models
{
    public class Antrenor
    {
        public int ID { get; set; }  // Cheia primara
        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [StringLength(30, ErrorMessage = "Numele nu poate avea mai mult de 30 de caractere.")]
        public string Nume { get; set; }  // Numele antrenorului
        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [StringLength(30, ErrorMessage = "Prenumele nu poate avea mai mult de 30 de caractere.")]
        public string Prenume { get; set; }  // Prenumele antrenorului
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Numarul de telefon trebuie sa inceapa cu 07 si sa aiba 10 cifre.")]
        public string? Telefon { get; set; }  // Numar de telefon

        public int? SpecializareID { get; set; }  // ID-ul specializarii (optional)
        public Specializare? Specializare { get; set; }  // Navigare catre specializare

        public string NumeComplet => $"{Nume} {Prenume}"; //Proprietate calculata
    }
}
