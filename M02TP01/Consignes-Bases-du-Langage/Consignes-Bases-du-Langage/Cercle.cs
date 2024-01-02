namespace Consignes_Bases_du_Langage.BO
{
    // Classe représentant un cercle
    public class Cercle : Forme
    {
        public double Rayon { get; set; }

        public override double CalculerPerimetre()
        {
            return 2 * Math.PI * Rayon;
        }

        public override double CalculerSurface()
        {
            return Math.PI * Rayon * Rayon;
        }

        public override string ToString()
        {
            return $"Cercle de Rayon {Rayon} Unités {Environment.NewLine} {base.ToString()}";
        }
    }
}