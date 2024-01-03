namespace TpLinq {
    public class Facture {
        public decimal Montant { get; private set; }
        public Auteur Auteur { get; private set; }
        public Facture(decimal montant, Auteur auteur) {
            Montant = montant;
            Auteur = auteur;
        }
    }
}