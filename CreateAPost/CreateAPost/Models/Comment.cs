using System.ComponentModel.DataAnnotations;

namespace CreateAPost.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Body { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}