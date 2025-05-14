using System.Collections.Generic;
using System.Threading.Tasks;
using BookBuzz.Models;

namespace BookBuzz.Services
{
    // Interface Segregation Principle:
    // This interface has a specific purpose dealing only with review operations
    public interface IReviewService
    {
        Task<List<Review>> GetReviewsByBookIdAsync(int bookId);
        Task AddReviewAsync(Review review);
        Task<double> GetAverageRatingForBookAsync(int bookId);
    }
} 