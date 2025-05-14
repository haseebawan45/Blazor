using System.Collections.Generic;
using System.Linq;
using BookBuzz.Models;

namespace BookBuzz.Filters
{
    // Open/Closed Principle:
    // This service applies filters without needing to change when new filters are added
    public class BookFilterService
    {
        public List<Book> ApplyFilters(List<Book> books, IEnumerable<IBookFilter> filters)
        {
            if (filters == null || !filters.Any())
            {
                return books;
            }

            return books.Where(book => filters.All(filter => filter.Matches(book))).ToList();
        }
    }
} 