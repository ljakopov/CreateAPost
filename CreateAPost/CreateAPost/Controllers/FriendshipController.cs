using CreateAPost.Dtos;
using CreateAPost.Models;
using Microsoft.AspNet.Identity;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace CreateAPost.Controllers
{

    public class FriendshipController : ApiController
    {
        private ApplicationDbContext _context;

        public FriendshipController()
        {
            _context=new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult FriendshipAdd(FriendshipDto dto)
        {
            var userId = User.Identity.GetUserId();
            Debug.WriteLine("TU SMO");
            if (_context.Friendships.Any(f => f.ApplicationUserId == userId && f.FriendUserId == dto.FriendId))
            {
                Debug.WriteLine("OVO JE ID: " + dto.FriendId);
                return BadRequest("Korisnika već pratite");
            }

            var friendsgip = new Friendship()
            {
                ApplicationUserId = userId,
                FriendUserId = dto.FriendId
            };

            _context.Friendships.Add(friendsgip);
            _context.SaveChanges();

            Debug.WriteLine("iofjeifj SPREMANJEEEE");

            return Ok();
        }
    }
}
