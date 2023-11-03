using N66_HT_Task1.DataAccess;
using N66_HT_Task1.Interfeys;
using N66_HT_Task1.Models;

namespace N66_HT_Task1.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDataContext _appDataContext;

        public AuthorService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        public async ValueTask<Author> CreateAsync(Author author)
        {
            var exsistingAuthor = _appDataContext.Authors.FirstOrDefault(x =>  x.FullName == author.FullName);
            if (exsistingAuthor != null)
                throw new InvalidOperationException("This Author already exsisting!!");

            await _appDataContext.Authors.AddAsync(author);

            await _appDataContext.SaveChangesAsync();   

            return author;
        }

        public async ValueTask<Author> DeleteAsync(string name)
        {
            var deletingAuthor = _appDataContext.Authors.FirstOrDefault(x => x.FullName == name);
            if (deletingAuthor == null)
            {
                throw new InvalidOperationException("This author is not exsisting!!");
            }
            _appDataContext.Authors.Remove(deletingAuthor);
            await _appDataContext.SaveChangesAsync();

            return deletingAuthor;


        }

        public ValueTask<Author> GetAsync(string name)
        {
            var getting = _appDataContext.Authors.FirstOrDefault(x => x.FullName == name);
            if (getting == null)
                throw new InvalidOperationException("this Auhtor does not exsisting!");

            return new(getting);
        }

        public async ValueTask<Author> UpdateAsync(Author author)
        {
            var updatingAuhtor = _appDataContext.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (updatingAuhtor == null)
                throw new InvalidOperationException("This Author is not exsisitng!");

            var newAuhtor = new Author
            {
                FullName = author.FullName
            };
            _appDataContext.Update(newAuhtor);
           await _appDataContext.SaveChangesAsync();
            return newAuhtor;
        }
    }
}
