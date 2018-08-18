using System.Collections.Generic;

namespace FiveCardStud
{
    public interface ICardDeck
    {
        List<ICard> DeckOfCards { get; set; }
        List<ICard> GetNewDeck();
    }
}
