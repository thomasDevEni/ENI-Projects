using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TpChat.Controllers
{
    public class ChatController : Controller
    {
        // GET: ChatController
        public ActionResult Index()
        {
            return View();
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
