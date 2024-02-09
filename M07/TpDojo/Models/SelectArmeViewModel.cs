using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TpDojo.Models
{
    public class SelectArmeViewModel
    {
        [DisplayName("Arme")]
        public int? IdArme { get; set; }

        public string Nom{ get; set; }
        public Arme Arme { get; set; }

        public List<Arme> ListeArme { get; set; }   

    }
}
