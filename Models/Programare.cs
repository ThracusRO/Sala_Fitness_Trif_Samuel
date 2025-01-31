using System.ComponentModel.DataAnnotations;

namespace Sala_Fitness_Trif_Samuel.Models
{
    public class Programare
    {
        public int ID { get; set; }  // Cheia primara

        public int? UtilizatorID { get; set; }  // ID-ul utilizatorului (optional)
        public Utilizator? Utilizator { get; set; }  // Navigare catre Utilizator

        public int? AntrenorID { get; set; }  // ID-ul antrenorului (optional)
        public Antrenor? Antrenor { get; set; }  // Navigare catre Antrenor
        
        [Display(Name = "Data Programare")]  // Am schimbat numele coloanei
        [Required(ErrorMessage = "Data programarii este obligatorie.")]
        [DataType(DataType.DateTime)]
        public DateTime DataProgramare { get; set; }  // Data si ora programarii
        
        [Required(ErrorMessage = "Durata programarii este obligatorie.")]
        [Range(30, 180, ErrorMessage = "Durata trebuie sa fie intre 30 si 180 de minute.")]
        [Display(Name = "Durata Minute")]
        public int DurataMinute { get; set; }  // Durata programarii in minute

        
    }
}
