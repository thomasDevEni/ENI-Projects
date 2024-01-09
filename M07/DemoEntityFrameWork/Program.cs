namespace DemoEntityFrameWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AppContext dbContext = new AppContext();
            dbContext.Personnes.Add(new Personne() { Nom = "Thomas REQUIER", Age = 41 });
            dbContext.SaveChanges();
        }
    }
}
