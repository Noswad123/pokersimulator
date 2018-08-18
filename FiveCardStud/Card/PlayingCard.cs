namespace FiveCardStud
{
    public class PlayingCard : ICard
    {
        public int Value { get; set; }
        public string Suit { get; set; }

        public PlayingCard(int value, string Suit)
        {
            this.Value = value;
            this.Suit = Suit;
        }
    }
}