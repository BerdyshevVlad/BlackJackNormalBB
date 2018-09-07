using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Interfaces
{
    public interface ICardRepository:IBaseRepository<Card>
    {
        bool IsExist();
    }
}
