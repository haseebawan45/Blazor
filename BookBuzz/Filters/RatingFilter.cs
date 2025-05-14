using BookBuzz.Models;

namespace BookBuzz.Filters
{
    // Open/Closed Principle:
    // Another concrete filter implementation that works without modifying existing code
    public class RatingFilter : IBookFilter
    {
        private readonly double _minimumRating;

        public RatingFilter(double minimumRating)
        {
            _minimumRating = minimumRating;
        }

        public bool Matches(Book book)
        {
            return book.AverageRating >= _minimumRating;
        }
    }
} 