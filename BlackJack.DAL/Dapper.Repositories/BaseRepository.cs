using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Dapper.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly string _connectionString = null;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException(); 
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(T item)
        {
            throw new NotImplementedException();
        }

        public Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
