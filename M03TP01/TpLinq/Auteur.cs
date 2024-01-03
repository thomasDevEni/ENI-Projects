namespace TpLinq {
    public class Auteur {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Facture> Factures { get; private set; }
        public Auteur(string prenom, string nom) {
            Prenom = prenom;
            Nom = nom;
            Factures = new List<Facture>();
        }
        public void AjouterFacture(Facture facture) {
            Factures.Add(facture);
        }
    }
}