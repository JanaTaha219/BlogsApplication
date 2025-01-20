using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Author { get; set; }

        [Required, StringLength(500, MinimumLength = 10)]
        public string Excerpt { get; set; }

        [Required, CategoryValidation]
        public string Category { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
