using TpPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
            return View();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
