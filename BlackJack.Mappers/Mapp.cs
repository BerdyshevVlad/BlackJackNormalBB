using BlackJack.DAL.Entities;
using BlackJack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Mappers
{
    public static class Mapp
    {
        public static CardViewModel MappCard(Card card)
        {
            CardViewModel viewModelCard = new CardViewModel
            {
                Id = card.Id,
                Value = card.Value,
                Suit = card.Suit,
                Rank=card.Rank
            };

            return viewModelCard;
        }


        public static List<CardViewModel> MappCard(List<Card> cardsList)
        {
            List<CardViewModel> viewModelCardsList = new List<CardViewModel>();

            foreach (var card in cardsList)
            {
                CardViewModel viewModelCard = MappCard(card);
                viewModelCardsList.Add(viewModelCard);
            }

            return viewModelCardsList;
        }


        public static PlayerViewModel MappPlayer(Player player)
        {
            PlayerViewModel viewModelPlayer = new PlayerViewModel
            {
                Id = player.Id,
                Name = player.Name,
                PlayerType = player.PlayerType,
            };

            return viewModelPlayer;
        }


        public static List<PlayerViewModel> MappPlayer(List<Player> playersList)
        {
            List<PlayerViewModel> viewModelPlayersList = new List<PlayerViewModel>();

            foreach (var player in playersList)
            {
                PlayerViewModel viewModelPlayer = MappPlayer(player);
                viewModelPlayersList.Add(viewModelPlayer);
            }

            return viewModelPlayersList;
        }


        public static Card MappCardModel(CardViewModel cardModel)
        {
            Card card = new Card();
            card.Id = cardModel.Id;
            card.Value = cardModel.Value;
            card.Suit = cardModel.Suit;
            card.Rank = cardModel.Rank;

            return card;
        }


        public static List<Card> MappCardModel(List<CardViewModel> cardModelList)
        {
            List<Card> cardsList = new List<Card>();
            foreach (var cardModel in cardModelList)
            {
                Card card = MappCardModel(cardModel);
                cardsList.Add(card);
            }

            return cardsList;
        }


        public static Player MappPlayerModel(PlayerViewModel playerModel)
        {
            Player player = new Player();
            player.Id = playerModel.Id;
            player.Name = playerModel.Name;
            player.PlayerType = playerModel.PlayerType;

            return player;
        }


        public static List<Player> MappPlayerModel(List<PlayerViewModel> playersModelList)
        {
            List<Player> playersList = new List<Player>();
            foreach (var playerModel in playersModelList)
            {
                Player player = MappPlayerModel(playerModel);
                playersList.Add(player);
            }

            return playersList;
        }
    }
}
