using System;
using System.Collections.Generic;

namespace FiveCardStud
{
    public class PokerHand : IHand
    {
        public List<ICard> Cards { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public bool IsWinner { get; set; } = false;
        
        public PokerHand(List<ICard> Hand)
        {
            this.Cards = Hand;
        }
        
        
    }
}
