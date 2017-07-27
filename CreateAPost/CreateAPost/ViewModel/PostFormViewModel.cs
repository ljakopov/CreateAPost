using System.ComponentModel.DataAnnotations;

namespace CreateAPost.ViewModel
{
    public class PostFormViewModel
    {
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
    }
}