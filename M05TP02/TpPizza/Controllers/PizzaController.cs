using TpPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.CodeAnalysis;

namespace TpPizza.Controllers
{
    public class PizzaController : Controller
    {
        
        // Liste de pizzas pour la simulation de persistance de données
        private static List<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza { Id=1,Nom = "Margherita", Pate = Pizza.PatesDisponibles[2], Ingredients = new List<Ingredient>{Pizza.IngredientsDisponibles[3], Pizza.IngredientsDisponibles[5] } },
            new Pizza { Id=2,Nom = "Pepperoni", Pate = Pizza.PatesDisponibles[1], Ingredients = new List<Ingredient>{Pizza.IngredientsDisponibles[7], Pizza.IngredientsDisponibles[5], Pizza.IngredientsDisponibles[0] } }
        };

        private static List<Pizza> _pizzasRepository = _pizzas.ToList();

        // GET: PizzaController:Action pour afficher la liste des pizzas
        public ActionResult Index()
        {
            return View(_pizzasRepository);
        }
        
        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            Pizza? pizza = _pizzasRepository.FirstOrDefault(x => x.Id == id);
            if (pizza==null)
            {
                return NotFound();  
                
            }
            return View(pizza);
        }
        
        // GET: PizzaController/Create
        public ActionResult Create()
        {
            var newPizza = new PizzaViewModel
            {
                Pizza = new Pizza(),
                Ingredients = Pizza.IngredientsDisponibles,
                Pates = Pizza.PatesDisponibles,
                PateSelectionne = new Pate(),
                IngredientsSelectionnes = new List<Ingredient>()
            };
            return View(newPizza);
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaViewModel newPizza)
        {
            try
            {
                _pizzasRepository.Add(newPizza.Pizza);
                // Traitement pour enregistrer la pizza dans la base de données
                // Utilisez viewModel.Pizza pour obtenir les détails de la pizza, y compris la pâte et les ingrédients sélectionnés
                return RedirectToAction(nameof(Index));
            }
            
            catch
            {
                
                return View(newPizza.Pizza);
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            // Logique pour récupérer la pizza avec l'ID spécifié depuis la base de données
            // Assurez-vous de charger les listes des pâtes et des ingrédients disponibles

            var viewModel = _pizzasRepository.FirstOrDefault(c => c.Id == id);
            if (viewModel == null) { return NotFound(); }
            {
                // Affectez la pizza à modifier à viewModel.Pizza
                // Chargez les listes des pâtes et des ingrédients disponibles dans viewModel.Pates et viewModel.Ingredients
            };
            return View(viewModel);

        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzaViewModel viewModel)
        {
            try
            {
                // Logique pour mettre à jour la pizza dans la base de données avec les nouvelles informations
                //methode 1
                int pizzaBddIndex = _pizzasRepository.FindIndex(x => x.Id == id);
                if (pizzaBddIndex == -1) return NotFound();


                _pizzasRepository[pizzaBddIndex].Nom = viewModel.Pizza.Nom;

                _pizzasRepository[pizzaBddIndex].Pate = viewModel.Pizza.Pate;

                _pizzasRepository[pizzaBddIndex].Ingredients = viewModel.Ingredients;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                viewModel.Pates = Pizza.PatesDisponibles;
                viewModel.Ingredients = Pizza.IngredientsDisponibles;
                return View(viewModel);
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza? pizza = _pizzasRepository.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                return NotFound();

            }
            return View(pizza);
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Pizza? pizza = _pizzasRepository.FirstOrDefault(x => x.Id == id);
                if (pizza == null)
                {
                    return NotFound();

                }
                _pizzasRepository.Remove(pizza);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
