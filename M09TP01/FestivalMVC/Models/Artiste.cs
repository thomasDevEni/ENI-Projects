using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivallWeb.Models
{
    public class Artiste
    {
        public int Id { get; set; }
        public string Nom{ get; set; }    
        public string Prenom { get; set; }

        public string Instrument { get; set; }
        public int? GroupeId { get; set; }

        public Groupe? Groupe { get; set; }
    }
}
