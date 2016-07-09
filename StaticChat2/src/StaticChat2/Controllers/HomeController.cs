using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaticChat.Models;
using Microsoft.EntityFrameworkCore;

namespace StaticChat.Controllers
{
    public class HomeController : Controller
    {
        ChatDbContext _db;

        public HomeController(ChatDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel { Messages =  _db.Messages.Include(x => x.Comments).ToList() };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Message mes)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            mes.When = DateTime.Now;          

            _db.Messages.Add(mes);          
            _db.SaveChanges();

            var model = new IndexViewModel { Messages = _db.Messages.Include(x => x.Comments).ToList() };
            return View(model);
        }

        
        public IActionResult About()
        {
            ViewData["Message"] = "It is a simple ASP.NETCore Application - Chat.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }
    }
}
