using FestivallWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FestivallWeb.ViewModels
{
    public class ArtisteViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Instrument { get; set; }
        public int? GroupeId { get; set; }

        public Models.Groupe? Groupe { get; set; }

        public SelectList? ChoixGroupe { get; set; }
    }
}
