using System.ComponentModel.DataAnnotations;

namespace Reddit.ViewModel
{
    public class CreatePostViewModel
    {
        [MaxLength(80)]
        [Required]

        public string Titel { get; set; }

        [MaxLength(255)]
        [Required]
        public string PostUrl { get; set; }
    }
}
