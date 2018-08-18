using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardStud
{
    public class PokerGameSimulator
    {
        public List<ICard> DeckOfCards;
        public List<IHand> Hands { get; set; }
        public HandEvaluator HandEvaluator = new HandEvaluator();
        public WinnerSelector WinnerSelector =  new WinnerSelector();

        public PokerGameSimulator(List<ICard> deckOfCards, List<IHand> Hands)
        {
            this.DeckOfCards = deckOfCards;
            this.Hands = Hands;
        }

        public void SimulateGame()
        {
            DealCards();
            EvaluateHands();
            
            DetermineWinner();

            ShowHands();
            DeclareWinner();
        }

        public void DealCards()
        { 
            for (int dealtCard = 0; dealtCard < Hands.Count * 5;)
            {
                foreach (IHand pokerHand in Hands)
                {
                    pokerHand.Cards.Add(DeckOfCards[dealtCard++]);
                }
            }
        }

        public void EvaluateHands()
        {
            foreach (var hand in Hands)
            {
                HandEvaluator.Evaluate(hand);
            }
        }

        public void ShowHands()
        {
            Console.WriteLine("\n");
            int handNumber = 1;
            foreach (IHand hand in Hands)
            {
                Console.WriteLine("Player" + handNumber + "'s hand");
                ShowHand(hand.Cards);
                Console.WriteLine();
                Console.WriteLine(Enum.GetName(typeof(PokerHandsEnum),hand.Value));
                handNumber++;
                Console.WriteLine("\n");
            }
        }

        public void ShowHand(List<ICard> cards)
        {
            foreach (ICard card in cards)
            {
                if (card.Value == 0 || card.Value == 10 || card.Value == 11 || card.Value == 12)
                {
                    Console.Write(Enum.GetName(typeof(CardNames), (card.Value)) + " of " + card.Suit + "s, ");
                }
                else
                {
                    Console.Write(card.Value + 1 + " of " + card.Suit + "s, ");
                }
            }
        }

        public void DetermineWinner()
        {
            WinnerSelector.SelectWinner(Hands);
        }

        public void DeclareWinner()
        {
            int playerCount;
            for(int i=0; i< Hands.Count;i++)
            {
                playerCount = i + 1;
                if (Hands[i].IsWinner)
                    Console.WriteLine("Player "+ playerCount + " wins"+"\n");
            }
        }
    }
}
