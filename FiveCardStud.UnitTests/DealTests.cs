using NUnit.Framework;
using System.Collections.Generic;

namespace FiveCardStud.UnitTests
{
    [TestFixture]
    public class DealTest
    {
        [Test]
        public void ShouldHaveFiveCardsEachForAGameOfTwoPlayers()
        {
            var deck = new ShuffledPokerDeck();
            var cardPlayers = new List<IHand>();

            var pokerHand1 = new PokerHand(new List<ICard>());
            var pokerHand2 = new PokerHand(new List<ICard>());

            cardPlayers.Add(pokerHand1);
            cardPlayers.Add(pokerHand2);
            var newGame = new PokerGameSimulator(deck.GetNewDeck(), cardPlayers);

            newGame.DealCards();
            int expectedValue = 5;

            Assert.IsTrue(newGame.Hands.TrueForAll(Hand => Hand.Cards.Count == expectedValue));
        }
        public void ShouldHaveFiveCardsEachForAGameOfFourPlayers()
        {
            var deck = new ShuffledPokerDeck();
            var cardPlayers = new List<IHand>() {
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>())
            };

            var newGame = new PokerGameSimulator(deck.GetNewDeck(), cardPlayers);
            newGame.DealCards();

            int expectedValue = 5;

            Assert.IsTrue(newGame.Hands.TrueForAll(Hand => Hand.Cards.Count == expectedValue));
        }
        public void ShouldHaveFiveCardsEachForAGameOf13Players()
        {
            var deck = new ShuffledPokerDeck();
            var cardPlayers = new List<IHand>(){
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>()),
                new PokerHand(new List<ICard>())
            };

            var newGame = new PokerGameSimulator(deck.GetNewDeck(), cardPlayers);

            newGame.DealCards();
            int expectedValue = 5;

            Assert.IsTrue(newGame.Hands.TrueForAll(Hand => Hand.Cards.Count == expectedValue));
        }
    }
}
