using System.Collections.Generic;

namespace FiveCardStud
{
    public abstract class StandardDeckBuilder : ICardDeck
    {
        public List<ICard> DeckOfCards { get; set; } = new List<ICard>();

        public StandardDeckBuilder()
        {
            for (int cardIndex = 0; cardIndex < 13; cardIndex++)
            {
                DeckOfCards.Add(new PlayingCard(cardIndex, "Diamond"));
                DeckOfCards.Add(new PlayingCard(cardIndex, "Spade"));
                DeckOfCards.Add(new PlayingCard(cardIndex, "Club"));
                DeckOfCards.Add(new PlayingCard(cardIndex, "Heart"));
            }
        }
        public List<ICard> GetNewDeck()
        {
            return DeckOfCards;
        }
    }
}
