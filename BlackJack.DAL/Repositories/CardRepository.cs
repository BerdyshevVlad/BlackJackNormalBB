using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository:ICardRepository<Card>
    {

        string connectionString = null;

        public CardRepository(string conn)
        {
            connectionString = conn;
        }


        //private readonly BlackJackContext _db;

        //public CardRepository(BlackJackContext context)
        //{
        //    _db = context;
        //}

        public async Task Insert(Card card)
        {
            //_db.Cards.Add(card);
            //await _db.SaveChangesAsync();


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Cards (Rank, Suit,Value) VALUES(@Rank, @Suit,@Value)";
                db.Execute(sqlQuery, card);
            }
        }

        public async Task Delete(int id)
        {
            //Card card = await _db.Cards.FindAsync(id);

            //if (card != null)
            //{
            //    _db.Cards.Remove(card);
            //    await _db.SaveChangesAsync();
            //}


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Cards WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {
            //IEnumerable<Card> cardsList = _db.Cards.Where(predicate);
            //return cardsList;


            IEnumerable<Card> card = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                card = db.Query<Card>("SELECT * FROM Cards").Where(predicate).ToList();
            }
            return card;

        }

        public async Task<Card> GetById(int id)
        {
            //Card card = await _db.Cards.FindAsync(id);

            //return card;


            Card card = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                card = db.Query<Card>("SELECT * FROM Cards WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return card;
        }


        public async Task<IEnumerable<Card>> GetAll()
        {

            //List<Card> cardsList = _db.Cards.ToList();
            //return cardsList;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Card>("SELECT * FROM Cards").ToList();
            }
        }

        public bool IsExist()
        {
            //var isExist = _db.Cards.Any();
            //return isExist;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var result= db.Query<Card>("SELECT * FROM Cards s WHERE Id = 1").DefaultIfEmpty();
                if(result.Any()==false){
                    return false;
                }
                return true;
            }
        }

        public async Task Update(Card card)
        {
            ////_db.Entry(card).State = EntityState.Modified;
            //await _db.SaveChangesAsync();


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Cards SET Rank=@Rank, Suit=@Suit,Value=@Value WHERE Id = @Id";
                db.Execute(sqlQuery, card);
            }

        }
    }
}
