using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPChats.Models;

namespace TpChats.Controllers
{
    public class ChatController : Controller
    {
        // GET: ChatController
        public ActionResult Index()
        {
             var v = Chat.GetMeuteDeChats();
            return View(v);
        }

        // GET: ChatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: ChatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatController/Delete/5
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
