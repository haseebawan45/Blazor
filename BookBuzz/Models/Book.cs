using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookBuzz.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Author { get; set; } = string.Empty;
        
        [Required]
        public string Genre { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string CoverImageUrl { get; set; } = string.Empty;
        
        public List<Review> Reviews { get; set; } = new List<Review>();
        
        public double AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
    }
} 