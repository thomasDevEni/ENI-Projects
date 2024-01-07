namespace TpPizza.Models
{
    public class PizzaViewModel
    {
        public Pate PateSelectionne { get; set; }
        public List<Ingredient> IngredientsSelectionnes { get; set; }
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }
    }
}
