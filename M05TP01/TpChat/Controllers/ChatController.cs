using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpChat.Models;
using TPChats.Models;

namespace TpChat.Controllers
{
    public class ChatController : Controller
    {
        // GET: ChatController
        public ActionResult Index()
        {
            var chatList = Chat.GetMeuteDeChats();
            return View(chatList);
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
