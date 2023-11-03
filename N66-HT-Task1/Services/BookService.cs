using N66_HT_Task1.DataAccess;
using N66_HT_Task1.Interfeys;
using N66_HT_Task1.Models;

namespace N66_HT_Task1.Services
{
    public class BookService : IBookService
    {
        private readonly AppDataContext _appDataContext;

        public BookService(AppDataContext appDataContext)
        {
            _appDataContext = new AppDataContext();
        }

        public async ValueTask<Book> CreateAsync(Book book)
        {
            var founderBook = _appDataContext.Books.FirstOrDefault(x => x.Id == book.Id);
            if (founderBook != null)
                throw new InvalidOperationException("This book already exsisting!!");

            await _appDataContext.Books.AddAsync(book);
            await _appDataContext.SaveChangesAsync();

            return book;
        }

        public async ValueTask<Book> DeleteAsync(int id)
        {
            var deletingBook = _appDataContext.Books.FirstOrDefault(x => x.Id == id);
            if(deletingBook == null)
                throw new InvalidOperationException("This book is not exsisting!!");

            _appDataContext.Books.Remove(deletingBook);
            await _appDataContext.SaveChangesAsync();

            return deletingBook;

        }

        public async ValueTask<Book> GetAsync(int id)
        {
            var existingBook = _appDataContext.Books.FirstOrDefault(x => x.Id == id);
            if(existingBook != null)
               return existingBook;

            throw new InvalidOperationException("This book is not exsisting!!");
        }

        public async ValueTask<Book> UpdateAsync(Book book)
        {
            var updatingBook = _appDataContext.Books.FirstOrDefault(x => x.Id == book.Id);
            if (updatingBook == null)
                throw new InvalidOperationException("This book is not exsisting!!");

            var newBook = new Book
            {
                Id = book.Id,
                BookName = book.BookName,
                Description = book.Description,
                Author_Id = book.Author_Id
            };

            await _appDataContext.AddAsync(newBook);
            await _appDataContext.SaveChangesAsync();

            return newBook;
        }
    }
}
