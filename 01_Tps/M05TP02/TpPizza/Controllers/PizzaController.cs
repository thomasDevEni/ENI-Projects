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
            return View(new PizzaViewModel());
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaViewModel newPizza)
        {
            try
            {
                if (Valider(newPizza))
                {
                    Pizza pizza = new Pizza
                    {
                        Id = _pizzasRepository.OrderByDescending(p => p.Id).FirstOrDefault()?.Id + 1 ?? 1,
                        Nom = newPizza.Nom,
                        Pate = Pizza.PatesDisponibles.First(p => p.Id == newPizza.IdPateSelectionne),
                        Ingredients = Pizza.IngredientsDisponibles.Where(i => newPizza.IdsIngredientsSelectionnes.Contains(i.Id)).ToList()
                    };
                    _pizzasRepository.Add(pizza);
                    return RedirectToAction(nameof(Index));
                }
                else return View(newPizza);
            }
            catch
            {
                return View(newPizza);
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            // Logique pour récupérer la pizza avec l'ID spécifié depuis la base de données
            // Assurez-vous de charger les listes des pâtes et des ingrédients disponibles

            Pizza? pizza = _pizzasRepository.FirstOrDefault(p => p.Id == id);
            if (pizza == null) return NotFound();
            PizzaViewModel pizzaVM = new PizzaViewModel
            {
                Id = pizza.Id,
                Nom = pizza.Nom,
                IdPateSelectionne = pizza.Pate.Id,
                IdsIngredientsSelectionnes = pizza.Ingredients.Select(i => i.Id).ToList()
            };
            return View(pizzaVM);

        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzaViewModel pizzaVM)
        {
            try
            {
                // Logique pour mettre à jour la pizza dans la base de données avec les nouvelles informations
                //methode 1
                if (id != pizzaVM.Id) return BadRequest();
                Pizza? pizza = _pizzasRepository.FirstOrDefault(p => p.Id == id);
                if (pizza == null) return NotFound();
                if (Valider(pizzaVM))
                {
                    pizza.Nom = pizzaVM.Nom;
                    pizza.Pate = Pizza.PatesDisponibles.First(p => p.Id == pizzaVM.IdPateSelectionne);
                    pizza.Ingredients = Pizza.IngredientsDisponibles
                        .Where(i => pizzaVM.IdsIngredientsSelectionnes.Contains(i.Id)).ToList();
                    return RedirectToAction(nameof(Index));
                }
                else return View(pizzaVM);
            }
            catch
            {
                return View(pizzaVM);
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

        private bool Valider(PizzaViewModel pizzaVM)
        {
            if (!ModelState.IsValid) return false;

            int nbIng = pizzaVM.IdsIngredientsSelectionnes.Count();
            if (nbIng < 2 || nbIng > 5)
            {
                ModelState.AddModelError("IdsIngredientsSelectionnes", "Une pizza doit avoir entre 2 et 5 ingrédients");
                return false;
            }

            string nomPizza = pizzaVM.Nom.ToLower();
            if (_pizzasRepository.Any(p => p.Nom.ToLower() == nomPizza && p.Id != pizzaVM.Id))
            {
                ModelState.AddModelError("Nom", "Une autre pizza porte déjà ce nom");
                return false;
            }

            if (_pizzasRepository.Where(p => p.Ingredients.Count() == nbIng && p.Id != pizzaVM.Id)
                .Any(p => p.Ingredients.All(i => pizzaVM.IdsIngredientsSelectionnes.Contains(i.Id))))
            {
                ModelState.AddModelError("IdsIngredientsSelectionnes",
                    "Deux pizzas ne peuvent avoir la même liste d'ingrédients");
                return false;
            }

            return true;
        }
    }
}
