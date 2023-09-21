using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore5Api.Data;
using NetCore5Api.Models;

namespace NetCore5Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<string> AddBookAsync(BookModel model)
        {
            var newBook = _mapper.Map<Book>(model);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id.ToString();
        }

        public async Task DeleteBookAsync(string id)
        {
            var deleteBook = _context.Books!.SingleOrDefault(b => b.Id == Guid.Parse(id));
            if (deleteBook != null)
            {
                _context.Books!.Remove(deleteBook);
                await _context.SaveChangesAsync();
            }

        }
        public async Task DeleteAllBookAsync()
        {

            await _context.SaveChangesAsync();

        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _context.Books!.ToListAsync();

            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetBookAsync(string id)
        {
            var book = await _context.Books!.FindAsync(Guid.Parse(id));
            return _mapper.Map<BookModel>(book);
        }

        public async Task UpdateBookAsync(string id, BookModel model)
        {
            var std = _context.Books!.FirstOrDefault(b => b.Id == Guid.Parse(id));
            if (std != null)
            {
                var newBook = _mapper.Map<Book>(model);
                std = newBook;
                await _context.SaveChangesAsync();
            }

        }
    }

}
