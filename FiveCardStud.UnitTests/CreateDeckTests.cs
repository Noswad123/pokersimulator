using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace FiveCardStud.UnitTests
{
    [TestFixture]
    public class CreateDeckTests
    {
        [Test]
        public void ShouldBeAbleToCreateADeckWithThe3OfHearts()
        {
            var deck = new ShuffledPokerDeck();
            Assert.IsTrue(deck.GetNewDeck().Where(card => card.Value == 3 && card.Suit == "Heart").Count() == 1);
        }
        [Test]
        public void ShouldBeAbleToCreateADeckOf52ItemsOfAnyKind()
        {
            var deck = new ShuffledPokerDeck();
            Assert.IsTrue(deck.GetNewDeck().Count == 52);
        }
        [Test]
        public void ShouldBeAbleToCreateAUniqueDeckOf52ItemsOfAnyKind()
        {
            var deck = new ShuffledPokerDeck();
            Assert.IsTrue(deck.GetNewDeck().Distinct().Count() == 52);
        }
        [Test]
        public void EachValueAppears4TimesInDeck()
        {
            var deck = new ShuffledPokerDeck();
            var valueList = new List<int>();
            for (int i = 0; i < 13; i++)
            {
                valueList.Add(i);
            }

            Assert.IsTrue(valueList.TrueForAll(value => {
                return deck.GetNewDeck()
                .FindAll(cardInDeck => cardInDeck.Value == value).Count == 4;
            }));
        }
        [Test]
        public void EachSuitAppears13TimesInDeck()
        {
            var deck = new ShuffledPokerDeck();
            var valueList = new List<string>() { "Heart", "Diamond", "Spade", "Club" };

            Assert.IsTrue(valueList.TrueForAll(value => {
                return deck.GetNewDeck()
                .FindAll(cardInDeck => cardInDeck.Suit == value).Count == 13;
            }));
        }

    }
}
