using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consignes_Bases_du_Langage.BO
{
    // Classe représentant un rectangle
    public class Rectangle : Forme
    {
        public double Longueur { get; set; }
        public double Largeur { get; set; }

        public override double CalculerSurface()
        {
            return Longueur * Largeur;
        }

        public override string ToString()
        {
            return $"Rectangle - {base.ToString()}";
        }
    }
}
