using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardStud.UnitTests
{

    [TestFixture]
    class WinnerSelectorTest
    {
        [Test]
        public void OnePairShouldWinInASinglePlayerGame()
        {
            var hand1 = new PokerHand(new List<ICard>()
            {
                new PlayingCard(1,"Club"),
                new PlayingCard(1,"Heart"),
                new PlayingCard(5,"Club"),
                new PlayingCard(7,"Club"),
                new PlayingCard(9,"Club"),
            });
          
            var handList = new List<IHand>() { hand1 };
            var winnerSelector = new WinnerSelector();

            winnerSelector.SelectWinner(handList);

            Assert.IsTrue(hand1.IsWinner);
        }
        [Test]
        public void OnePairShouldWinAgainstHighCard()
        {

            var hand1 = new PokerHand(new List<ICard>()
            {
                new PlayingCard(6,"Club"),
                new PlayingCard(1,"Heart"),
                new PlayingCard(5,"Club"),
                new PlayingCard(7,"Club"),
                new PlayingCard(9,"Club"),
            });
            var hand2 = new PokerHand(new List<ICard>()
            {
                new PlayingCard(1,"Club"),
                new PlayingCard(1,"Heart"),
                new PlayingCard(5,"Club"),
                new PlayingCard(7,"Club"),
                new PlayingCard(9,"Club"),
            });

            var handList = new List<IHand>()
            { hand1, hand2 };
            var handEvaluator = new HandEvaluator();
            handEvaluator.Evaluate(handList);

            var winnerSelector = new WinnerSelector();
            winnerSelector.SelectWinner(handList);

            Assert.IsTrue(hand2.IsWinner);
        }
        [Test]
        public void HighCardHandWithLargerHighCardShouldWin()
        {

            var hand1 = new PokerHand(new List<ICard>()
            {
                new PlayingCard(11,"Club"),
                new PlayingCard(1,"Heart"),
                new PlayingCard(5,"Club"),
                new PlayingCard(7,"Club"),
                new PlayingCard(9,"Club"),
            });
            var hand2 = new PokerHand(new List<ICard>()
            {
                new PlayingCard(2,"Club"),
                new PlayingCard(1,"Heart"),
                new PlayingCard(5,"Club"),
                new PlayingCard(7,"Club"),
                new PlayingCard(9,"Club"),
            });

            var hand3 = new PokerHand(new List<ICard>()
            {
                new PlayingCard(12,"Club"),
                new PlayingCard(1,"Heart"),
                new PlayingCard(5,"Club"),
                new PlayingCard(7,"Club"),
                new PlayingCard(9,"Club"),
            });

            var handList = new List<IHand>()
            { hand1, hand2, hand3 };

            var handEvaluator = new HandEvaluator();
            handEvaluator.Evaluate(handList);

            var winnerSelector = new WinnerSelector();
            winnerSelector.SelectWinner(handList);

            Assert.IsTrue(hand3.IsWinner);
        }
    }
}
