using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BatailleCorseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jeuJoueur1 = new Anneau();
            var jeuJoueur2 = new Anneau();

            // Initialisation du jeu de 32 cartes
            for (int valeur = 7; valeur <= 14; valeur++)
            {
                jeuJoueur1.AjouterEnFin(new Carte(valeur));
                jeuJoueur2.AjouterEnFin(new Carte(valeur));
            }

            while (!jeuJoueur1.EstVide() && !jeuJoueur2.EstVide())
            {
                var carteJoueur1 = jeuJoueur1.RetirerDuDebut();
                var carteJoueur2 = jeuJoueur2.RetirerDuDebut();

                if (carteJoueur1.Valeur > carteJoueur2.Valeur)
                {
                    Console.WriteLine("Le joueur 1 remporte la manche !");
                }
                else if (carteJoueur2.Valeur > carteJoueur1.Valeur)
                {
                    Console.WriteLine("Le joueur 2 remporte la manche !");
                }
                else
                {
                    Console.WriteLine("Égalité !");
                }
            }

            if (jeuJoueur1.EstVide() && jeuJoueur2.EstVide())
            {
                Console.WriteLine("La partie est nulle !");
            }
            else if (jeuJoueur1.EstVide())
            {
                Console.WriteLine("Le joueur 2 a gagné !");
            }
            else
            {
                Console.WriteLine("Le joueur 1 a gagné !");
            }
        }
    }
}
