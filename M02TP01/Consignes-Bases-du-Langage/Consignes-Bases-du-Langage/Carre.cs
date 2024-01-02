﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consignes_Bases_du_Langage.BO
{
    // Classe représentant un carré
    public class Carre : Forme
    {
        public double Longueur { get; set; }

        public override double CalculerPerimetre()
        {
            return 4 * (Longueur );
        }

        public override double CalculerSurface()
        {
            return Longueur * Longueur;
        }

        public override string ToString()
        {
            return $"Carré - {base.ToString()}";
        }
    }
}
