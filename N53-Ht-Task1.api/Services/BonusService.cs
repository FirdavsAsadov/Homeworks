using N53_Ht_Task1.api.DataAccess;
using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;
using System.Linq.Expressions;

namespace N53_Ht_Task1.api.Services
{
    public class BonusService : IBonusService
    {
        private readonly IDataContext  _dataContext;
        public BonusService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async ValueTask<Bonus> CreateAsync(Bonus bonus)
        {
            var result = await _dataContext.Bonus.AddAsync(bonus);

            await _dataContext.SaveChangesAsync();

            return result.Entity;
        }

        public IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate)
             => _dataContext.Bonus.Where(predicate.Compile()).AsQueryable();

        public async ValueTask<Bonus> UpdateAsync(Bonus bonus)
        {
            var updatedBonus = _dataContext.Bonus.FirstOrDefault(x => x.Id == bonus.Id);
            if (updatedBonus == null)
                throw new Exception("This Bonus Not found");
            updatedBonus.Amount = bonus.Amount;
            await _dataContext.SaveChangesAsync();
            return updatedBonus;
        }
    }
}
