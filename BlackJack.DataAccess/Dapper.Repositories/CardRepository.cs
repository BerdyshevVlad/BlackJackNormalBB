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
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(string connectionString) : base(connectionString)
        {

        }

        public bool IsExistAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                bool isExist = db.GetAll<Card>().Any();
                return isExist;
            }
        }
    }
}
