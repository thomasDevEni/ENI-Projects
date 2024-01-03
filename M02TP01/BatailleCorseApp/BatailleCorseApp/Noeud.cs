using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCorseApp
{
    public class Noeud
    {
        public Carte Carte { get; set; }
        public Noeud Prochain { get; set; }

        public Noeud(Carte carte)
        {
            Carte = carte;
            Prochain = null;
        }
    }
}
