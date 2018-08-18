using System.Collections.Generic;
using System;
using System.Linq;

namespace FiveCardStud
{
    public class WinnerSelector
    {
        private List<IHand> SortedHands;
        private List<IHand> TopHands;

        public void SelectWinner(List<IHand> Hands)
        {
            SortedHands = Hands.OrderByDescending(hand => hand.Value).ToList();
            if(SortedHands.Select(hand=>hand.Value).Distinct().Count()==SortedHands.Count)
            {
                SortedHands[0].IsWinner = true;
            }
            else
            {
                FilterTopHands();
                FactorInKicker();
            }
        }
       private void FilterTopHands()
        {
            TopHands = SortedHands.FindAll(hand=>hand.Value==SortedHands[0].Value).ToList();
        }
        private void FactorInKicker()
        {
            for(int i = 0; i<TopHands.Count;i++)
            {
                TopHands[i].Cards=TopHands[i].Cards.OrderByDescending(card => card.Value).ToList();
            }
            if(TopHands.TrueForAll(hand=>hand.Value==(int)PokerHandsEnum.HighCard))
                TopHands = TopHands.OrderByDescending(hand => hand.Cards[0].Value).ToList();
            /*else if(TopHands.TrueForAll(hand => hand.Value == (int)PokerHandsEnum.OnePair))
            {
                IHand greatestPairHand=TopHands[0];
                
                int greatestPairValue= TopHands[0].Cards.GroupBy(card => card.Value).Select(group => group.First()).ToList()[0].Value;
                for(int i = 0; i < TopHands.Count; i++)
                {
                    if (greatestPairValue < TopHands[i].Cards.FindAll(card=>).GroupBy(card => card.Value).Select(group => group.First()).ToList()[0].Value)
                    {
                        greatestPairValue = TopHands[i].Cards.GroupBy(card => card.Value).Select(group => group.First()).ToList()[0].Value;
                        greatestPairHand = TopHands[i];
                    }
                }
                greatestPairHand.IsWinner=true;
            }*/
            else
                TopHands = TopHands.OrderByDescending(hand => hand.Cards[0].Value).ToList();

            TopHands[0].IsWinner = true;
        }
    }
}
