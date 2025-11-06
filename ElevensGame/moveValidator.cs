using System;
using System.Collections.Generic;
using System.Linq;

public class MoveValidator
{
    // Checks if two selected cards sum to 11.
    public bool isValidPair(List<Card> cards)
    {
        if (cards == null || cards.Count != 2) return false;
        return (cards[0].getValue() + cards[1].getValue() == 11);
    }

    // Checks if three selected cards are Jack, Queen, and King.
    public bool isValidTriple(List<Card> cards)
    {
        if (cards == null || cards.Count != 3) return false;
        
        // Check if the ranks contain J, Q, and K.
        var ranks = cards.Select(c => c.getRank()).ToList();
        return ranks.Contains("Jack") && 
               ranks.Contains("Queen") && 
               ranks.Contains("King");
    }

    // Determines if any valid pair or triple still exists on the table.
    public bool hasLegalMoves(List<Card> tableCards)
    {
        if (tableCards == null || tableCards.Count < 2) return false;

        // Check for 11-pairs
        for (int i = 0; i < tableCards.Count; i++)
        {
            for (int j = i + 1; j < tableCards.Count; j++)
            {
                if (tableCards[i].getValue() + tableCards[j].getValue() == 11)
                {
                    return true;
                }
            }
        }

        // Check for J-Q-K triple
        if (tableCards.Count >= 3)
        {
            bool hasJack = tableCards.Any(c => c.getRank() == "Jack");
            bool hasQueen = tableCards.Any(c => c.getRank() == "Queen");
            bool hasKing = tableCards.Any(c => c.getRank() == "King");

            if (hasJack && hasQueen && hasKing)
            {
                return true;
            }
        }
        return false;
    }
}