using CreateAPost.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CreateAPost.Controllers
{
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Users
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var notFriends = _context.Users.Where(u => u.Id != userId).ToList();

            return View(notFriends);
        }
    }
}