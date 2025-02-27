using LibraryManagementApp.Data;
using LibraryManagementApp.Model;
using LibraryManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Repositories.Implementation
{
    public class BooksRepository(AppDbContext context) : IBooksRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> AddBooks(Books books)
        {
            _context.Books.Add(books);
            return await SaveBook();
        }

        public bool booksexist(string id)
        {
            return _context.Books.Any(b => b.Id == id);

        }

        public async Task<bool> DeleteBook(string id)
        {
            var books = await GetAllBooksbyId(id);
            _context.Books.Remove(books);
            return await SaveBook();
        }

        public async Task<IEnumerable<Books>> GetAllBooks()
        {
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public async Task<Books> GetAllBooksbyId(string id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> UpdateBooks(Books books)
        {
            _context.Books.Update(books);
            return await SaveBook();
        }

        public async Task<bool> SaveBook()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<Dictionary<string, List<Books>>> GetBooksGroupedByAuthor()
        {
            var booksList = await _context.Books.ToListAsync();
            var groupedBooks = booksList.GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.ToList());
            return groupedBooks;
        }
        public async Task<List<Books>> GetTopBorrowedBooks(int topCount)
        {
            return await _context.Books.OrderByDescending(b => b.BorrowCount).Take(topCount).ToListAsync();
        }
    }
}
