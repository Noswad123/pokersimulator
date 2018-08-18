using NUnit.Framework;
using System.Collections.Generic;

namespace Demo
{
    [TestFixture]
    public class Demo
    {
        [Test]
        public void CheckFor52Cards()
        {
            var newGame = new CardGame();
            Assert.IsTrue(newGame.CreateCards().Count == 52);
        }
        [Test]
        public void CheckForAHeart()
        {
            var newGame = new CardGame();
            var actual = newGame.CreateCards().FindAll(Card => Card.Suit == "Heart").Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CheckFor13Heart()
        {
            var newGame = new CardGame();
            var actual = newGame.CreateCards().FindAll(Card => Card.Suit == "Heart").Count;
            var expected = 13;

            Assert.AreEqual(expected, actual);
        }
    }
}
