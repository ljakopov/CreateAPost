using CreateAPost.Models;
using System.Collections.Generic;

namespace CreateAPost.ViewModel
{
    public class PostViewModel
    {
        public IEnumerable<Post> UsersPosts { get; set; }

        public bool UserAuth { get; set; }
    }
}