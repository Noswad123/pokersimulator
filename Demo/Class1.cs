using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class CardGame
    {
        public List<Card> CreateCards()
        {
            List<Card> cardList = new List<Card>();
            for(int i=0; i<52;i++)
            {
                if(i<13)
                    cardList.Add(new Card(i,"Heart"));
                else
                    cardList.Add(new Card(i, "Club"));
            }
            return cardList;
        }
    }
}
