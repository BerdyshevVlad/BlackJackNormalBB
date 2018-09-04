using BlackJack.EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BlackJack.DAL
{
    public class BlackJackContext : Microsoft.EntityFrameworkCore.DbContext
    {

        //For ASP MVC
        //static BlackJackContext()
        //{
        //    Database.SetInitializer<BlackJackContext>(new ContextInitializer());
        //}

        //public BlackJackContext() : base("BlackJackContext")
        //{ }

        //public DbSet<Card> Cards { get; set; }
        //public DbSet<Player> Players { get; set; }
        //public DbSet<PlayerCard> PlayersCards { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Card> Cards { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Player> Players { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<PlayerCard> PlayersCards { get; set; }
        public BlackJackContext(DbContextOptions<BlackJackContext> options)
            : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                //ignore
            }
        }
    }


    //For ASP MVC
    //public class ContextInitializer : CreateDatabaseIfNotExists<BlackJackContext>
    //{
    //    protected override void Seed(BlackJackContext context)
    //    {

    //    }
    //}
}
