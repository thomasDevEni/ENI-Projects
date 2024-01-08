using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace TpPizza.Models
{
    public class PizzaViewModel
    {
        public Pizza PizzaSelect { get; set; }

        [DisplayName("Pâte")]
        public int IdPateSelectionne { get; set; }
        public List<Pate> Pates { get; set; }
        public SelectList choixPate { get { return new SelectList(Pizza.PatesDisponibles, "Id", "Nom"); } }

        [DisplayName("Ingredients")]
        public List<int> IdsIngredientsSelectionnes { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        
        public SelectList choixIngredients { get { return new SelectList(Pizza.IngredientsDisponibles, "Id", "Nom"); } }
        
    }
}
