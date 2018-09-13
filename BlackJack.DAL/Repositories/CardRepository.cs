using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(BlackJackContext context):base(context)
        {
            
        }

        public bool IsExist()
        {
            var isExist = _dbContext.Cards.Any();
            return isExist;
        }
    }
}
