using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TpPizza.Models
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom d'une pizza est obligatoire")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le nom de la pizza doit contenir entre {2} et {1} caractères")]
        public string Nom { get; set; }

        [DisplayName("Pâte")]
        [Required(ErrorMessage = "Une pizza doit nécessairement avoir une pâte")]
        public int IdPateSelectionne { get; set; }
        public SelectList choixPate { get { return new SelectList(Pizza.PatesDisponibles, "Id", "Nom"); } }

        [DisplayName("Ingredients")]
        public List<int> IdsIngredientsSelectionnes { get; set; }               
        public SelectList choixIngredients { get { return new SelectList(Pizza.IngredientsDisponibles, "Id", "Nom"); } }
        
    }
}
