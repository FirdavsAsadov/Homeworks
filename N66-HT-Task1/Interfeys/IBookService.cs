using N66_HT_Task1.Models;

namespace N66_HT_Task1.Interfeys
{
    public interface IBookService
    {
        ValueTask<Book> CreateAsync(Book book);
        ValueTask<Book> UpdateAsync(Book book);
        ValueTask<Book> DeleteAsync(int id);
        ValueTask<Book> GetAsync(int id);
    }
}
