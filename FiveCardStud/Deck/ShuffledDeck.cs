using System;
using System.Collections.Generic;

namespace FiveCardStud
{
    public class ShuffledPokerDeck : StandardDeckBuilder
    {
        public ShuffledPokerDeck() : base()
        {
            ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            var randNum = new Random();
            int randIndex;
            var shuffledDeck = new List<ICard>();
            Console.WriteLine("The Deck is Shuffled");

            while (DeckOfCards.Count > 0)
            {
                randIndex = randNum.Next(DeckOfCards.Count - 1);
                shuffledDeck.Add(DeckOfCards[randIndex]);
                DeckOfCards.RemoveAt(randIndex);
            }
            DeckOfCards = shuffledDeck;

            foreach (ICard card in DeckOfCards)
            {
                Console.WriteLine(card.Suit + " " + card.Value);
            }
        }
    }
}
