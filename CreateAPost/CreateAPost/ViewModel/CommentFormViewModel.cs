using System.ComponentModel.DataAnnotations;

namespace CreateAPost.ViewModel
{
    public class CommentFormViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }
    }
}