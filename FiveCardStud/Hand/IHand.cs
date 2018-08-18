using System.Collections.Generic;

namespace FiveCardStud
{
    public interface IHand
    {
        List<ICard> Cards { get; set; }
        bool IsWinner { get; set; }
        string Name { get; set; }
        int Value { get; set; }
    }
}
