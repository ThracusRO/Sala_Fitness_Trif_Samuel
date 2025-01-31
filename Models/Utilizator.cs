using System.ComponentModel.DataAnnotations;

namespace Sala_Fitness_Trif_Samuel.Models
{
    public class Utilizator
    {
        public int ID { get; set; }  // Cheia primara (unic pentru fiecare utilizator)
        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [StringLength(30, ErrorMessage = "Numele nu poate avea mai mult de 30 de caractere.")]
        public string Nume { get; set; }  // Numele utilizatorului
        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [StringLength(30, ErrorMessage = "Prenumele nu poate avea mai mult de 30 de caractere.")]
        public string Prenume { get; set; }  // Prenumele utilizatorului
        [Required(ErrorMessage = "Email-ul este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este valida.")]
        public string Email { get; set; }  // Emailul utilizatorului
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Numarul de telefon trebuie sa inceapa cu 07 si sa aiba 10 cifre.")]
        public string? Telefon { get; set; }  // Numar de telefon
        [DataType(DataType.Date)]
        [Display(Name = "Data Nașterii")]
        public DateTime? DataNasterii { get; set; }  // Data nasterii
        [Required(ErrorMessage = "Genul este obligatoriu.")]
        [RegularExpression("Masculin|Feminin|Alt", ErrorMessage = "Genul trebuie sa fie 'Masculin', 'Feminin' sau 'Alt'.")]
        public string Gen { get; set; }  // Genul utilizatorului (Masculin/Feminin/Alt)

        public int? AbonamentID { get; set; }  // ID-ul abonamentului (optional)
        public Abonament? Abonament { get; set; }  // Navigare catre modelul Abonament

        public string NumeComplet => $"{Nume} {Prenume}"; //Proprietate calculata
    }
}
