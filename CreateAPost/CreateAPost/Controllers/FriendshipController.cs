using CreateAPost.Models;
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
        public IHttpActionResult FriendshipAdd()
        {
            return Ok();
        }
    }
}
