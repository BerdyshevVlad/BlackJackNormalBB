using BlackJack.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlackJack.DataAccess.Context.Core
{
    public class BlackJackContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Card> Cards { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Player> Players { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<PlayerCard> PlayersCards { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ExceptionDetail> ExceptionDetails { get; set; }
        public BlackJackContext(DbContextOptions<BlackJackContext> options)
            : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
