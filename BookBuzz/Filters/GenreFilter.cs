using BookBuzz.Models;

namespace BookBuzz.Filters
{
    // Open/Closed Principle:
    // A concrete filter implementation that can be used without modifying existing code
    public class GenreFilter : IBookFilter
    {
        private readonly string _genre;

        public GenreFilter(string genre)
        {
            _genre = genre;
        }

        public bool Matches(Book book)
        {
            return string.IsNullOrEmpty(_genre) || book.Genre == _genre;
        }
    }
} 