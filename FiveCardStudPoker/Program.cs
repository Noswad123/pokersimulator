using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardStud
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new UnShuffledPokerDeck();
            var pokerHands = new HandListBuilder();
            var newGame = new PokerGameSimulator(deck.GetNewDeck(), pokerHands.CreateListOfHands(8));
            
            newGame.SimulateGame();
        }
    }
}
