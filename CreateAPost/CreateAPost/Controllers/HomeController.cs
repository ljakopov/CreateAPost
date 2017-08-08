using CreateAPost.Models;
using CreateAPost.ViewModel;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CreateAPost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var posts = _context.Posts
                .Where(p => p.UserId == userId)
                .Include(p=>p.Comments)
                .Include(p => p.User)
                .ToList();

            
            var viewModel = new PostViewModel()
            {
                UsersPosts = posts,
                UserAuth = User.Identity.IsAuthenticated
            };

    

            var viewModelPartialPostViewModel = new PartialPostViewModel();
            viewModelPartialPostViewModel.PostViewModel = viewModel;

            return View(viewModelPartialPostViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}