using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaticChat.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StaticChat.Controllers
{
    public class CommentController : Controller
    {
        ChatDbContext _db;

        public CommentController(ChatDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel { Messages = _db.Messages.Include(x => x.Comments).ToList() };
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Index(Comment com)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            _db.Comments.Add(com);
            _db.SaveChanges();

            var model = new IndexViewModel { Messages = _db.Messages.Include(x => x.Comments).ToList() };
            return RedirectToAction("Index", "Home");
        }
    }
}
