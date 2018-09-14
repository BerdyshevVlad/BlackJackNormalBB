using BlackJack.DAL.Dapper.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DAL.Dapper.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly string _connectionString = null;

        public CardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task Insert(Card card)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Cards (Rank, Suit,Value) VALUES(@Rank, @Suit,@Value)";
                db.Execute(sqlQuery, card);
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Cards WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {

            IEnumerable<Card> card = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                card = db.Query<Card>("SELECT * FROM Cards").Where(predicate).ToList();
            }
            return card;

        }

        public async Task<Card> GetById(int id)
        {

            Card card = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                card = db.Query<Card>("SELECT * FROM Cards WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return card;
        }


        public async Task<IEnumerable<Card>> GetAll()
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Card>("SELECT * FROM Cards").ToList();
            }
        }

        public bool IsExist()
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = db.Query<Card>("SELECT * FROM Cards WHERE Id = 1").DefaultIfEmpty();
                if (result.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task Update(Card card)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Cards SET Rank=@Rank, Suit=@Suit,Value=@Value WHERE Id = @Id";
                db.Execute(sqlQuery, card);
            }

        }
    }
}
