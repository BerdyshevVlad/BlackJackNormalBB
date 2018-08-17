
using BlackJack.DAL.Entities;
using BlackJack.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    class Program
    {
        static void Main(string[] args)

        {
            var context = new BlackJack.DAL.BlackJackContext();
            //PlayerRepository playerRepository = new PlayerRepository(context);
            //CardRepository cardRepository = new CardRepository(context);


            


            List<string> suitsList = new List<string> ( new string[] { "Spades", "Hearts", "Clubs", "Diamonds"} );
            foreach (var suit in suitsList)
            {
                for (var value = 1; value <= 14; value++)
                {
                    Card card = new Card { Value = value };
                    context.Cards.Add(card);
                    context.SaveChanges();
                }
            }

            

            Player player1 = new Player {Name="Player1",PlayerType="Player" };
            Player player2 = new Player {Name="Player2",PlayerType= "Player" };

            context.Players.Add(player1);
            context.Players.Add(player2);


            Random random = new Random();
            var playersList = context.Players.ToList();




            int currentRound=0;
            try
            {
                if (context.PlayersCards.Max(x => x.CurrentRound)>0)
                {
                    currentRound = context.PlayersCards.Max(x => x.CurrentRound)+1;
                }
            }
            catch
            {
                currentRound = 1;
            }


            for (int j = 0; j < 5; j++)
            {


            for (int i = 0; i < playersList.Count(); i++)
            {

                var randomCardId=random.Next(1, 53);
                Card card = context.Cards.Find(randomCardId);
                

                    context.Entry(card).State = EntityState.Modified;
                    context.SaveChanges();

                    var tmpPlayer = context.Players.Find(player1.Id);
                    var tmpCard =  context.Cards.Find(card.Id);

                    var tmpPlayersCards = new PlayerCard()
                    {
                        //PlayerId = tmpPlayer.Id,
                        //CardId = tmpCard.Id,
                        CurrentRound = currentRound
                    };

                    context.PlayersCards.Add(tmpPlayersCards);

                    context.SaveChanges();
            }

            }


            //var cardList1 = playerRepository.GetAllCardsFromPlayer(player1.Id);
            //var cardList2 = playerRepository.GetAllCardsFromPlayer(player2.Id);

            //foreach (var card in cardList1)
            //{
            //    Console.WriteLine(card.Value);
            //}

            //Console.WriteLine("**************");

            //foreach (var card in cardList2)
            //{
            //    Console.WriteLine(card.Value);
            //}

            Console.WriteLine("Ok!");
        }
    }
}
