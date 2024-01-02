namespace Consignes_Bases_du_Langage.BO
{        // Classe de base pour les formes géométriques
        public abstract class Forme
        {
            public abstract double CalculerSurface();
            public abstract double CalculerPerimetre();
            public override string ToString()
            {
                return $"Périmètre: {CalculerPerimetre()} unités\n Surface: {CalculerSurface()} unités carrées";
            }
        }
 
}