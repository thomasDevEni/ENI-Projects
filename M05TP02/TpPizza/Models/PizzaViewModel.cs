namespace TpPizza.Models
{
    public class PizzaViewModel
    {
        public int PateSelectionne { get; set; }
        public List<int> IngredientsSelectionnes { get; set; }
        public Pizza PizzaSelect { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }
    }
}
