using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateAPost.Models
{
    public class Friendship
    {
        [Key]
        [Column(Order = 1)]
        public string ApplicationUserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FriendUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


        public ApplicationUser FriendUser { get; set; }

    }
}