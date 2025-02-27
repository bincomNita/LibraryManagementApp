using LibraryManagementApp.Model;

namespace LibraryManagementApp.Repositories.Interface
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Books>> GetAllBooks();
        Task<Books> GetAllBooksbyId(string id);
        Task<Dictionary<string, List<Books>>> GetBooksGroupedByAuthor();
        Task<List<Books>> GetTopBorrowedBooks(int topCount);
        Task<bool> AddBooks(Books books);
        Task<bool> UpdateBooks(Books books);
        Task<bool> DeleteBook(string id);
        bool booksexist(string id);
        Task<bool> SaveBook();
    }
}
