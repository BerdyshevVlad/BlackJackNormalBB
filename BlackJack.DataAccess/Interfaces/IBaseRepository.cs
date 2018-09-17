using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task InsertAsync(T item);
        Task DeleteAsync(int id);
        IEnumerable<T> FindAsync(Func<T, bool> predicate);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T item);
    }
}
