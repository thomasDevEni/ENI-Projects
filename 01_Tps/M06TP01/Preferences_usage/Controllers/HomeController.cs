using Microsoft.AspNetCore.Mvc;
using Preferences_usage.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Xml.Linq;

namespace Preferences_usage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;
        int compteur = 0;   

        

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            // Récupérer la couleur choisie par l'utilisateur depuis la session
            string? selectedColor = HttpContext.Session.GetString("SelectedColor");
            // Récupérer les couleurs disponibles depuis le cache (simulé ici)
            var availableColors = GetAvailableColors();
            var valeurExistEnCache = !_memoryCache.TryGetValue("demoCache", out String valeurEnCache);

            string? cookieVisites = Request.Cookies["visits"] ?? "0";
            var compteur = int.Parse(cookieVisites);
            compteur++;

            if (valeurExistEnCache)
            {

                Thread.Sleep(1000); //simulation d'un traitement long
                valeurEnCache = "Valeur en cache";
                _memoryCache.Set("demoCache", valeurEnCache);
            }
            TempData["valeur"] = valeurEnCache;

            if (selectedColor == null)
            {
                TempData["SelectedColor"] = "Pas de couleur en session";
            }
            else
            {
                TempData["SelectedColor"] = selectedColor;
            }

            // Gestion du cookie pour le nombre de visites
            
             Response.Cookies.Append("visits", compteur.ToString());        
             ViewBag.VisitsCount = compteur;

            
            // Stocker les couleurs disponibles dans ViewBag pour la vue
            ViewBag.AvailableColors = availableColors;
            
            // Si aucune couleur n'est sélectionnée, définir la couleur par défaut comme noir
            ViewBag.SelectedColor = string.IsNullOrEmpty(selectedColor) ? "black" : selectedColor;

            return View();

        }
        public IActionResult Themes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Themes(string color)
        {
            // Récupérer la couleur choisie par l'utilisateur depuis la session
            string? selectedColor = HttpContext.Session.GetString("SelectedColor");
            // Stocker la couleur choisie par l'utilisateur dans la session
            selectedColor = color;

            return RedirectToAction("Index");
        }

        // Méthode factice pour simuler les couleurs disponibles en cache
        private string[] GetAvailableColors()
        {
            return new string[] { "blue", "red", "green", "black" };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
