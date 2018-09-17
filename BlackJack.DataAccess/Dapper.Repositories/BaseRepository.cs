using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BlackJack.DataAccess.Dapper.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly string _connectionString = null;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task DeleteAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                T itemById = await db.GetAsync<T>(id);
                await db.DeleteAsync<T>(itemById);
            }
        }

        public IEnumerable<T> FindAsync(Func<T, bool> predicate)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<T> listItem =db.GetAll<T>().Where(predicate);
                return listItem;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<T> itemList=await db.GetAllAsync<T>();
                return itemList;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               T itemById=await db.GetAsync<T>(id);
               return itemById;
            }
        }

        public async Task InsertAsync(T item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.InsertAsync<T>(item);
            }
        }

        public async Task UpdateAsync(T item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.UpdateAsync<T>(item);
            }
        }
    }
}
