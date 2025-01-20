using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class BlogDTO
    {
        [Required, StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Author { get; set; }

        [Required, StringLength(500, MinimumLength = 10)]
        public string Excerpt { get; set; }

        [Required, CategoryValidation]
        public string Category { get; set; }
    }

    public class CategoryValidation : ValidationAttribute
    {
        private static readonly List<string> AllowedCategories = new List<string>
        {
            "Technology", "Health", "Education", "Travel", "Lifestyle"
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string category && AllowedCategories.Contains(category))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid category. Please select a valid category.");
        }
    }
}
