using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuzz.Models;

namespace BookBuzz.Services
{
    // Single Responsibility Principle:
    // This class is only responsible for operations related to books
    public class BookService : IBookService
    {
        private List<Book> _books;

        public BookService()
        {
            // Initialize with some sample data
            _books = new List<Book>
            {
                // Pakistani books
                new Book
                {
                    Id = 1,
                    Title = "The Reluctant Fundamentalist",
                    Author = "Mohsin Hamid",
                    Genre = "Pakistani Literature",
                    Description = "A monologue by a Pakistani man, Changez, to an American stranger in Lahore about his experiences in the United States and his eventual abandonment of America.",
                    CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9a/The_Reluctant_Fundamentalist.jpg"
                },
                new Book
                {
                    Id = 2,
                    Title = "A Case of Exploding Mangoes",
                    Author = "Mohammed Hanif",
                    Genre = "Pakistani Literature",
                    Description = "A satirical novel based on the plane crash that killed General Muhammad Zia ul-Haq, former President of Pakistan, examining the circumstances around his death.",
                    CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b0/A_Case_of_Exploding_Mangoes.jpg"
                },
                new Book
                {
                    Id = 3,
                    Title = "Moth Smoke",
                    Author = "Mohsin Hamid",
                    Genre = "Pakistani Literature",
                    Description = "Set in Lahore, it tells the story of Darashikoh Shezad, a banker who loses his job, falls in love with his best friend's wife, and plunges into a life of drugs and crime.",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1560822993l/40343532._SX318_.jpg"
                },
                new Book
                {
                    Id = 4,
                    Title = "The Shadow of the Crescent Moon",
                    Author = "Fatima Bhutto",
                    Genre = "Pakistani Literature",
                    Description = "A story set in a small town in Pakistan's tribal regions, close to the Afghan border, that follows three brothers over the course of one morning.",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1381365295l/18467763.jpg"
                },
                new Book
                {
                    Id = 5,
                    Title = "Home Fire",
                    Author = "Kamila Shamsie",
                    Genre = "Pakistani Literature",
                    Description = "A modern retelling of Sophocles's Antigone, set in London, following the story of three British Muslim siblings and exploring themes of identity, loyalty, and radicalization.",
                    CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/32/Home_Fire_%28novel%29.jpg"
                },
                new Book
                {
                    Id = 6,
                    Title = "The Crow Eaters",
                    Author = "Bapsi Sidhwa",
                    Genre = "Pakistani Literature",
                    Description = "A humorous novel about a Parsi family in the early 20th century, chronicling their migration from a village to Lahore and their experiences in pre-partition India.",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1389489731l/155214.jpg"
                },
                new Book
                {
                    Id = 7,
                    Title = "Trespassing",
                    Author = "Uzma Aslam Khan",
                    Genre = "Pakistani Literature",
                    Description = "Set in Karachi, it weaves together the stories of a silk farmer's daughter and a young man returning from the US, exploring themes of love, globalization, and politics.",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1181223411l/1282856.jpg"
                },
                new Book
                {
                    Id = 8,
                    Title = "Season of the Rainbirds",
                    Author = "Nadeem Aslam",
                    Genre = "Pakistani Literature",
                    Description = "Set in a small Pakistani town, the novel explores the aftermath of a local judge's murder and the recovery of a bag of letters lost in a train crash nineteen years earlier.",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1347353551l/1320419.jpg"
                },
                new Book
                {
                    Id = 9,
                    Title = "Exit West",
                    Author = "Mohsin Hamid",
                    Genre = "Contemporary Fiction",
                    Description = "A love story set against the backdrop of a world in crisis, following two young people as they flee their country through magical doors that lead to other cities around the globe.",
                    CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b9/Exit_West_%28Mohsin_Hamid%29.jpg"
                },
                new Book
                {
                    Id = 10,
                    Title = "Kartography",
                    Author = "Kamila Shamsie",
                    Genre = "Pakistani Literature",
                    Description = "Set in Karachi during the 1990s, it follows childhood friends Raheen and Karim as they navigate love, friendship, and family secrets against the backdrop of ethnic violence.",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1388214444l/272486.jpg"
                },
                new Book
                {
                    Id = 11,
                    Title = "How to Get Filthy Rich in Rising Asia",
                    Author = "Mohsin Hamid",
                    Genre = "Contemporary Fiction",
                    Description = "Written in the second person and styled as a self-help book, it follows the journey of an unnamed protagonist from rural poverty to corporate success in a rapidly changing Asia.",
                    CoverImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/12/How_to_Get_Filthy_Rich_in_Rising_Asia.jpg"
                },
                new Book
                {
                    Id = 12,
                    Title = "In Other Rooms, Other Wonders",
                    Author = "Daniyal Mueenuddin",
                    Genre = "Short Stories",
                    Description = "A collection of interconnected short stories exploring the lives of people across the social hierarchy in contemporary Pakistan, from servants to landlords.",
                    CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1320427558l/5326236.jpg"
                }
            };
        }

        public Task<List<Book>> GetAllBooksAsync()
        {
            return Task.FromResult(_books);
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            return Task.FromResult(_books.FirstOrDefault(b => b.Id == id));
        }

        public Task<List<Book>> GetBooksByGenreAsync(string genre)
        {
            return Task.FromResult(_books.Where(b => b.Genre == genre).ToList());
        }

        public Task<List<string>> GetAllGenresAsync()
        {
            return Task.FromResult(_books.Select(b => b.Genre).Distinct().ToList());
        }

        public Task AddBookAsync(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task UpdateBookAsync(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                var index = _books.IndexOf(existingBook);
                _books[index] = book;
            }
            return Task.CompletedTask;
        }
    }
}