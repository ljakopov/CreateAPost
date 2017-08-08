using CreateAPost.Models;
using CreateAPost.ViewModel;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace CreateAPost.Controllers
{
    public class CommentsController : Controller
    {

        private ApplicationDbContext _context;

        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartialPostViewModel viewModel, int id)
        {
            var comment = new Comment()
            {
                Body = viewModel.CommentFormViewModel.Body,
                PostId = id,
                ApplicationUserId = User.Identity.GetUserId()                
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}