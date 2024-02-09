using System.ComponentModel.DataAnnotations;

namespace TpDojo.Models
{
    public class Samourai
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom d'un Samouraï est Obligatoire")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Le nom du Samouraï doit contenir entre {2} et {1} caractères")]
        public string Nom { get; set; }
        public int? Force { get; set; }

        public int? ArmeId { get; set; }

        public Arme? Arme { get; set; }
    }
}
