using System.Collections.Generic;
using System.Threading.Tasks;
using BookBuzz.Models;

namespace BookBuzz.Services
{
    // Interface Segregation Principle:
    // This interface has a specific purpose and doesn't force implementations
    // to provide methods they don't need
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<List<Book>> GetBooksByGenreAsync(string genre);
        Task<List<string>> GetAllGenresAsync();
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
    }
} 