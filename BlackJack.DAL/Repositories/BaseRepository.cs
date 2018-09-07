using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: Entity
    {
        protected readonly BlackJackContext _dbContext;
        public BaseRepository(BlackJackContext context)
        {
            _dbContext = context;
        }

        public async Task Delete(int id)
        {

            T item = await _dbContext.FindAsync<T>(id);

            if (item != null)
            {
                _dbContext.Remove<T>(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            IEnumerable<T> cardsList = _dbContext.Set<T>().Where(predicate);
            return cardsList;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> itemList = _dbContext.Set<T>();
            return itemList;
        }

        public async Task<T> GetById(int id)
        {
            T item = await _dbContext.Set<T>().FindAsync(id);

            return item;
        }

        public async Task Insert(T item)
        {
            _dbContext.Set<T>().Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
