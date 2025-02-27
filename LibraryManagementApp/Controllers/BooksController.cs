using LibraryManagementApp.Model;
using LibraryManagementApp.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]    
    public class BooksController(IBooksRepository booksRepository) : ControllerBase
    {
        private readonly IBooksRepository _booksRepository = booksRepository;

        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var Getbooks = _booksRepository.GetAllBooks();
            return Ok(Getbooks);
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllBooksbyId(string id)
        {
            if (!_booksRepository.booksexist(id))
                return NotFound();
            var Getbooks = await _booksRepository.GetAllBooksbyId(id);
            return Ok(Getbooks);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]        
        public async Task<IActionResult> AddBooks(Books books)
        {
            if (books == null) return BadRequest(ModelState);
            var createdbook = await _booksRepository.AddBooks(books);
            if (!createdbook) return BadRequest("Error while adding book");
            return Ok("New book added");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]      
        public async Task<IActionResult> UpdateBooks(Books books)
        {
            if (books == null) return BadRequest(ModelState);

            var Updatebook = await _booksRepository.UpdateBooks(books);
            if (!Updatebook) return BadRequest("Error while Updating book");
            return Ok("book Updated");
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]        
        public async Task<IActionResult> DeleteBook(string id)
        {

            var book = await _booksRepository.GetAllBooksbyId(id);
            if (book == null)
                return NotFound($"book with ID {id} not found.");
            var isDeleted = await _booksRepository.DeleteBook(id);
            if (!isDeleted)
                return BadRequest("Error while deleting the book.");

            return Ok($"book with ID {id} deleted successfully.");
        }

        [HttpGet("grouped-by-author")]
        public async Task<IActionResult> GetBooksGroupedByAuthor()
        {
            var groupedBooks = await _booksRepository.GetBooksGroupedByAuthor();
            return Ok(groupedBooks);
        }

        [HttpGet("top-borrowed")]
        public async Task<IActionResult> GetTopBorrowedBooks([FromQuery] int count = 3)
        {
            var topBooks = await _booksRepository.GetTopBorrowedBooks(count);
            return Ok(topBooks);
        }
    }
}
