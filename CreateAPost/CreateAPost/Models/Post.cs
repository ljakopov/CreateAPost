using System;
using System.ComponentModel.DataAnnotations;

namespace CreateAPost.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Text { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

    }
}