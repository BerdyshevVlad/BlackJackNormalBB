namespace BlackJack.Entities
{
    public class Player:BaseEntity
    {
        public string Name { get; set; }
        public string PlayerType { get; set; }
        public int GameNumber { get; set; }
    }
}
