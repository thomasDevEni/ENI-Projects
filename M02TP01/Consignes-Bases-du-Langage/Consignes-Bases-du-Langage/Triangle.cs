namespace Consignes_Bases_du_Langage.BO
{
    // Classe représentant un triangle
    public class Triangle : Forme
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public override double CalculerSurface()
        {
            // Utilisation de la formule de Heron pour calculer la surface d'un triangle à partir des longueurs des côtés
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override string ToString()
        {
            return $"Triangle - {base.ToString()}";
        }
    }
}