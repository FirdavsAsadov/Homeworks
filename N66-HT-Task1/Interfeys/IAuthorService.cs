using N66_HT_Task1.Models;

namespace N66_HT_Task1.Interfeys
{
    public interface IAuthorService
    {
        ValueTask<Author> CreateAsync (Author author);
        ValueTask<Author> UpdateAsync (Author author);
        ValueTask<Author> DeleteAsync (string  name);
        ValueTask<Author> GetAsync (string name);
    }
}
