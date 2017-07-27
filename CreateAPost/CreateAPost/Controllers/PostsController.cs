using CreateAPost.Models;
using CreateAPost.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace CreateAPost.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            var post = new Post()
            {
                Text = viewModel.Text,
                DateTime = DateTime.Now,
                UserId = User.Identity.GetUserId()
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        
        
    }
}