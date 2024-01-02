namespace Consignes_Bases_du_Langage.BO
{        // Classe de base pour les formes géométriques
        public abstract class Forme
        {
            public abstract double CalculerSurface();
            public override string ToString()
            {
                return $"Surface: {CalculerSurface()} unités carrées";
            }
        }
 
}