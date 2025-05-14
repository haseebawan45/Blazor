using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuzz.Models;

namespace BookBuzz.Services
{
    // Single Responsibility Principle:
    // This class is only responsible for operations related to reviews
    public class ReviewService : IReviewService
    {
        private List<Review> _reviews;
        private readonly IBookService _bookService;

        // Dependency Inversion Principle:
        // Depends on abstraction (IBookService) rather than concrete implementation
        public ReviewService(IBookService bookService)
        {
            _bookService = bookService;
            _reviews = new List<Review>
            {
                new Review
                {
                    Id = 1,
                    BookId = 1,
                    Rating = 5,
                    Comment = "A true classic that everyone should read.",
                    ReviewerName = "John Doe"
                },
                new Review
                {
                    Id = 2,
                    BookId = 1,
                    Rating = 4,
                    Comment = "Great character development but a bit slow in places.",
                    ReviewerName = "Jane Smith"
                },
                new Review
                {
                    Id = 3,
                    BookId = 2,
                    Rating = 5,
                    Comment = "This book is more relevant today than ever.",
                    ReviewerName = "Mike Johnson"
                }
            };
        }

        public Task<List<Review>> GetReviewsByBookIdAsync(int bookId)
        {
            return Task.FromResult(_reviews.Where(r => r.BookId == bookId).ToList());
        }

        public Task AddReviewAsync(Review review)
        {
            review.Id = _reviews.Count > 0 ? _reviews.Max(r => r.Id) + 1 : 1;
            _reviews.Add(review);
            return Task.CompletedTask;
        }

        public async Task<double> GetAverageRatingForBookAsync(int bookId)
        {
            var reviews = await GetReviewsByBookIdAsync(bookId);
            return reviews.Any() ? reviews.Average(r => r.Rating) : 0;
        }
    }
}