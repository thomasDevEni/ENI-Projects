namespace DemoEntityFrameWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Base de Données de Personnes");
            AppContext dbContext = new AppContext();
            //dbContext.Personnes.Add(new Personne() { Nom = "Thomas REQUIER", Age = 41 });
            //dbContext.Personnes.Add(new Personne() { Nom = "Jo TRUBADOUR", Age = 61 });
            //dbContext.Personnes.Add(new Personne() { Nom = "Ada LOVELACE", Age = 93 });

            //dbContext.SaveChanges();

            Console.WriteLine("Personnes:");
            foreach(var item in dbContext.Personnes)
            {
                Console.WriteLine(item.Nom);
            }

            Console.WriteLine("Consultation d'une personne par des critères de recherche:");

            var p = dbContext.Personnes
                .SingleOrDefault(x=>x.Nom == "Jo TRUBADOUR");

            p.Nom = "Yves ROCHER";
            dbContext.Personnes.Remove(p);
            dbContext.SaveChanges();
            Console.WriteLine("Personnes:");
            foreach (var item in dbContext.Personnes)
            {
                Console.WriteLine(item.Nom);
            }
        }
    }
}
