using System.Collections.Generic;
using BookBuzz.Models;

namespace BookBuzz.Filters
{
    // Open/Closed Principle:
    // This interface allows for new filtering strategies to be added
    // without modifying existing code
    public interface IBookFilter
    {
        bool Matches(Book book);
    }
} 