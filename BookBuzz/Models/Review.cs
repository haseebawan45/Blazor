using System;
using System.ComponentModel.DataAnnotations;

namespace BookBuzz.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }
        
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars")]
        public int Rating { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Review comment must be at least 3 characters")]
        public string Comment { get; set; } = string.Empty;
        
        public string ReviewerName { get; set; } = string.Empty;
        
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
} 