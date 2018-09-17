using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.DataAccess.Context.Core;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BlackJackContext _dbContext;
        public BaseRepository(BlackJackContext context)
        {
            _dbContext = context;
        }

        public async Task DeleteAsync(int id)
        {

            T item = await _dbContext.FindAsync<T>(id);

            if (item != null)
            {
                _dbContext.Remove<T>(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<T> FindAsync(Func<T, bool> predicate)
        {
            IEnumerable<T> cardsList = _dbContext.Set<T>().Where(predicate);
            return cardsList;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> itemList = _dbContext.Set<T>();
            return itemList;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T item = await _dbContext.Set<T>().FindAsync(id);

            return item;
        }

        public async Task InsertAsync(T item)
        {
            _dbContext.Set<T>().Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
