namespace TpLinq {
    public class Livre {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Synopsis { get; set; }
        public int NbPages { get; set; }
        public Auteur Auteur { get; set; }
        public Livre(int id, string titre, string synopsis, int nbpages, Auteur auteur) {
            Id = id;
            Titre = titre;
            Synopsis = synopsis;
            NbPages = nbpages;
            Auteur = auteur;
        }
    }
}