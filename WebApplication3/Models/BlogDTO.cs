using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    //We use DTO to create and update product.
    public class BlogDTO
    {
        [Required, StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Author { get; set; }

        [Required, StringLength(500, MinimumLength = 10)]
        public string Excerpt { get; set; }

        [Required, StringLength(100)]
        public string Category { get; set; }
    }
}
