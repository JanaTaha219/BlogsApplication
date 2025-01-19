using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 10)]
        [Required]
        public string Excerpt { get; set; }

        [StringLength(100)]
        [Required]
        public string Category { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
