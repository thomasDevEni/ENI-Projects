using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TPChats.Models;

namespace TpChats.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> _chats = Chat.GetMeuteDeChats();

        // GET: ChatController
        public ActionResult Index()
        {
             return View(_chats);
        }

        // GET: ChatController/Details/5
        public ActionResult Details(int id)
        {
            var chat = _chats.FirstOrDefault(c => c.Id == id);
               
            return View(chat);
        }



        // GET: ChatController/Delete/5
        public ActionResult Delete(int id)
        {
            var chatToRemove = _chats.FirstOrDefault(c => c.Id == id);
            
                return View(chatToRemove);
   
        }

        // POST: ChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var chat = _chats.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            _chats.Remove(chat);

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
