using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardStud
{
    public class GameSetup
    {
        public  GameSetup(PokerGameSimulator newGame, List<IHand> hands)
        {
             newGame.WinnerSelector = new WinnerSelector();
            newGame.HandEvaluator = new HandEvaluator();
            newGame.Hands = hands;
        }
    }
}
