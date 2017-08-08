using CreateAPost.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
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

            var friends = _context.Friendships.Where(f => f.ApplicationUserId == userId).Include(f => f.FriendUser)
                .ToList();


            return View(friends);
        }

        public ActionResult NonFrends()
        {/*
            var userId = User.Identity.GetUserId();

            var friends = _context.Friendships.Where(f => f.ApplicationUserId == userId).ToArray();
            Debug.WriteLine("ISPIS: " + friends);
            var friendsA = _context.Users.Where(u => u.Id != friends).ToList();
            */

            return View();
        }



    }
}