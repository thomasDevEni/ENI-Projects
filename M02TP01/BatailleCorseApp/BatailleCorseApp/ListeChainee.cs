using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCorseApp
{
    public class ListeChainee
    {
        public Noeud Premier { get; set; }
        public Noeud Dernier { get; set; }

        public ListeChainee()
        {
            Premier = null;
            Dernier = null;
        }

        public void AjouterEnFin(Carte carte)
        {
            var nouveauNoeud = new Noeud(carte);

            if (Dernier == null)
            {
                Premier = nouveauNoeud;
                Dernier = nouveauNoeud;
            }
            else
            {
                Dernier.Prochain = nouveauNoeud;
                Dernier = nouveauNoeud;
            }
        }

        public Carte RetirerDuDebut()
        {
            if (Premier == null)
            {
                return null;
            }

            var carteRetiree = Premier.Carte;
            Premier = Premier.Prochain;

            if (Premier == null)
            {
                Dernier = null;
            }

            return carteRetiree;
        }

        public bool EstVide()
        {
            return Premier == null;
        }
    }
}
