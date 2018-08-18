using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardStud
{
    public class HandListBuilder
    {
        public List<IHand> HandList = new List<IHand>();
        public List<IHand> CreateListOfHands(int numHands)
        {
            for (int i = 0; i < numHands; i++)
            {
                HandList.Add(CreateHand());
            }
            return HandList;
        }
        public IHand CreateHand()
        {
            return new PokerHand(new List<ICard>());
        }
    }
}
