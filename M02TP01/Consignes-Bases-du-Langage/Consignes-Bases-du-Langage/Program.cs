using System.Drawing;

namespace Consignes_Bases_du_Langage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Classe de base pour les formes géométriques
            public abstract class Forme
                {
                    public abstract double CalculerSurface();
                    public override string ToString()
                    {
                        return $"Surface: {CalculerSurface()} unités carrées";
                    }
                }
            // Classe représentant un cercle
            public class Cercle : Forme
            {
                public double Rayon { get; set; }

                public override double CalculerSurface()
                {
                    return Math.PI * Rayon * Rayon;
                }

                public override string ToString()
                {
                    return $"Cercle - {base.ToString()}";
                }
            }
            var formes = new List<Forme> {
                new Cercle { Rayon = 3 },
                new Rectangle { Longueur = 4, Largeur = 3 },
                new Carre { Longueur = 3 },
                new Triangle { A = 4, B = 5, C = 6 }
            };
            foreach (Forme forme in formes)
            {
                Console.WriteLine(forme);
            }
        }
    }
}
