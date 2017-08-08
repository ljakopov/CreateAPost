using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CreateAPost.Models
{
    public class Post
    {
        public ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new Collection<Comment>(); ;
        }

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