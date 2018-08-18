using NUnit.Framework;
using System.Collections.Generic;

namespace FiveCardStud.UnitTests
{
    [TestFixture]
    class HandEvaluatorTest
    {
        [Test]
        public void ShouldBeAbleToDetectAHighCardHand()
        {
            var pokerHand = new PokerHand(new List<ICard> {
                new PlayingCard(1, "Diamond"),
                new PlayingCard(8, "Club"),
                new PlayingCard(3, "Diamond"),
                new PlayingCard(4, "Diamond"),
                new PlayingCard(5, "Diamond")
            });
            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.HighCard;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetectOnePair()
        {
            var pokerHand = new PokerHand(new List<ICard> {
                new PlayingCard(1, "Diamond"),
                new PlayingCard(1, "Club"),
                new PlayingCard(3, "Diamond"),
                new PlayingCard(4, "Diamond"),
                new PlayingCard(5, "Diamond")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.OnePair;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetect4OfAKind()
        {
            var pokerHand = new PokerHand(new List<ICard> {
                new PlayingCard(1, "Diamond"),
                new PlayingCard(1, "Club"),
                new PlayingCard(1, "Spade"),
                new PlayingCard(1, "Heart"),
                new PlayingCard(5, "Diamond")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.FourOfAKind;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected,pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetect3OfAKind()
        {
            var pokerHand = new PokerHand(new List<ICard>
            {
                new PlayingCard(1, "Diamond"),
                new PlayingCard(1, "Club"),
                new PlayingCard(1, "Spade"),
                new PlayingCard(2, "Heart"),
                new PlayingCard(5, "Diamond")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.ThreeOfAKind;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetectTwoPair()
        {
            var pokerHand = new PokerHand(new List<ICard>
            {
                new PlayingCard(1, "Diamond"),
                new PlayingCard(1, "Club"),
                new PlayingCard(3, "Spade"),
                new PlayingCard(5, "Heart"),
                new PlayingCard(5, "Diamond")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.TwoPair;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetectFullHouse()
        {
            var pokerHand = new PokerHand(new List<ICard>
            {
                new PlayingCard(1, "Diamond"),
                new PlayingCard(1, "Club"),
                new PlayingCard(1, "Spade"),
                new PlayingCard(5, "Heart"),
                new PlayingCard(5, "Diamond")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.FullHouse;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [TestCase("Diamond")]
        [TestCase("Spade")]
        [TestCase("Heart")]
        [TestCase("Club")]
        public void ShouldBeAbleToDetectFlush(string suit)
        {
            var pokerHand = new PokerHand(new List<ICard>
            {
                new PlayingCard(1, suit),
                new PlayingCard(2, suit),
                new PlayingCard(7, suit),
                new PlayingCard(9, suit),
                new PlayingCard(5, suit)
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.Flush;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetectAStraight()
        {
            var pokerHand = new PokerHand(new List<ICard>
            {
                new PlayingCard(1,"Club" ),
                new PlayingCard(2, "Heart" ),
                new PlayingCard(5, "Diamon"),
                new PlayingCard(4, "Heart"),
                new PlayingCard(3, "Spade")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.Straight;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetectAnAceHighStraight()
        {
            var pokerHand = new PokerHand(new List<ICard>
            {
                new PlayingCard(0,"Club" ),
                new PlayingCard(10, "Heart" ),
                new PlayingCard(11, "Diamon"),
                new PlayingCard(12, "Heart"),
                new PlayingCard(9, "Spade")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.Straight;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
        [Test]
        public void ShouldBeAbleToDetectAnStraightFlush()
        {
            var pokerHand = new PokerHand(new List<ICard>
            {
                new PlayingCard(0,"Club" ),
                new PlayingCard(10, "Club" ),
                new PlayingCard(11, "Club"),
                new PlayingCard(12, "Club"),
                new PlayingCard(9, "Club")
            });

            var handEvaluator = new HandEvaluator();
            var expected = (int)PokerHandsEnum.StraightFlush;
            handEvaluator.Evaluate(pokerHand);
            Assert.AreEqual(expected, pokerHand.Value);
        }
    }
}
