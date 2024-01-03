using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCorseApp
{
    public class Maillon
    {
        public Carte Carte { get; set; }
        public Maillon Prochain { get; set; }

        public Maillon(Carte carte)
        {
            Carte = carte;
            Prochain = null;
        }
    }
}
