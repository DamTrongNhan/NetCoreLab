using NetCore5Api.Models;

namespace NetCore5Api.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();
        public Task<BookModel> GetBookAsync(string id);
        public Task<string> AddBookAsync(BookModel model);
        public Task UpdateBookAsync(string id, BookModel model);
        public Task DeleteBookAsync(string id);
        public Task DeleteAllBookAsync();

    }
}
