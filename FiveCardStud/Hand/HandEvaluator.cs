using System;
using System.Collections.Generic;
using System.Linq;

namespace FiveCardStud
{
    public class HandEvaluator
    {
        List<ICard> UniqueCards;
        List<ICard> SortedCards;
        public void Evaluate(List<IHand> handsToEvaluate)
        {
            foreach (IHand hand in handsToEvaluate)
                Evaluate(hand);
        }
        public void Evaluate(IHand handToEvaluate)
        {
            OrderCardsFromSmallestToLargest(handToEvaluate);
            if (IsFlush(handToEvaluate))
            {
                 CheckRoyalOrStraightFlush(handToEvaluate);
            }
            else if (IsStraight())
            {
                AssignValue((int)PokerHandsEnum.Straight, handToEvaluate);
            }
            else
            {

                if (UniqueCards.Count == 4)
                    AssignValue((int)PokerHandsEnum.OnePair, handToEvaluate);
                else if (UniqueCards.Count == 3)
                     CheckForThreeOfAKindOrTwoPair( handToEvaluate);
                else if (UniqueCards.Count == 2)
                    CheckForFourOfAKindOrFullHouse(handToEvaluate);
                else
                    AssignValue((int)PokerHandsEnum.HighCard, handToEvaluate);
            }
        }

        public void OrderCardsFromSmallestToLargest(IHand handToEvaluate)
        {
            SortedCards = handToEvaluate.Cards.OrderBy(card => card.Value).ToList<ICard>();
            FilterUniqueCards();
        }
        private void FilterUniqueCards()
        {
            UniqueCards = SortedCards.GroupBy(card => card.Value).Select(group => group.First()).ToList();
        }
        public void AssignValue(int value, IHand handToEvaluate)
        {
            handToEvaluate.Value = value; 
        }
        public bool IsFlush(IHand handToEvaluate)
        {
            return handToEvaluate.Cards.TrueForAll(card => card.Suit == handToEvaluate.Cards[0].Suit);
        }

        private void CheckRoyalOrStraightFlush(IHand handToEvaluate)
        {
            if (IsStraight())
            {
                if (handToEvaluate.Cards[0].Value == 9)
                    AssignValue((int)PokerHandsEnum.RoyalFlush, handToEvaluate);
                else
                    AssignValue((int)PokerHandsEnum.StraightFlush, handToEvaluate);
            }
            else
                AssignValue((int)PokerHandsEnum.Flush, handToEvaluate);
        }

        private bool IsStraight()
        {
            int startingIndex = SortedCards[0].Value == 0 && SortedCards[1].Value == 9 ? 1 : 0;
            for (var cardIndex = startingIndex; cardIndex < SortedCards.Count - 1; cardIndex++)
            {
                if (Math.Abs(SortedCards[cardIndex].Value - SortedCards[cardIndex + 1].Value) != 1)
                    return false;
            }
            return true;
        }
        private void CheckForThreeOfAKindOrTwoPair( IHand handToEvaluate)
        {
            var listOfCountForEachCard = new List<int>();
            foreach (ICard card in UniqueCards)
            {
                listOfCountForEachCard.Add(
                    handToEvaluate.Cards.FindAll(c => c.Value == card.Value).Count);
            }
            if (listOfCountForEachCard.Contains(3))
                AssignValue((int)PokerHandsEnum.ThreeOfAKind, handToEvaluate);
            else
                AssignValue((int)PokerHandsEnum.TwoPair, handToEvaluate);
        }

        private void CheckForFourOfAKindOrFullHouse( IHand handToEvaluate)
        {
            if(
                handToEvaluate.Cards.FindAll(card => card.Value == UniqueCards[0].Value).ToList().Count==1
                || handToEvaluate.Cards.FindAll(card => card.Value == UniqueCards[0].Value).ToList().Count == 4)
            {
                AssignValue((int)PokerHandsEnum.FourOfAKind, handToEvaluate);
            }
            else
            {
                AssignValue((int)PokerHandsEnum.FullHouse, handToEvaluate);
            }
        }
    }
}
