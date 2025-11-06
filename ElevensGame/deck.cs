using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    // Fields
    // Initialized inline to silence CS8618 warning.
    private List<Card> cards = new List<Card>();
    private int currentCardIndex;
    private static Random Rng = new Random(); 

    // Creates a standard 52-card deck and initializes it.
    public Deck()
    {
        InitializeDeck();
    }

    // Populates the deck with 52 standard playing cards.
    private void InitializeDeck()
    {
        cards.Clear();
        currentCardIndex = 0;

        for (int i = 0; i < Card.Suits.Length; i++)
        {
            for (int j = 0; j < Card.Ranks.Length; j++)
            {
                string rank = Card.Ranks[j];
                string suit = Card.Suits[i];
                int value;

                if (j >= 10) // Jack, Queen, King
                {
                    value = 10;
                }
                else
                {
                    value = j + 1; // Ace=1, 2=2, etc.
                }

                cards.Add(new Card(rank, suit, value));
            }
        }
    }

    // Randomly rearranges the cards in the deck.
    public void shuffle()
    {
        currentCardIndex = 0; // Reset index

        // Fisher-Yates shuffle algorithm
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    // Deals and returns the next card from the deck (nullable).
    public Card? dealCard() 
    {
        if (currentCardIndex < cards.Count)
        {
            return cards[currentCardIndex++]; // Return card and advance index
        }
        return null; // Deck is empty
    }

    // Returns true if no cards remain in the deck.
    public bool isEmpty()
    {
        return currentCardIndex >= cards.Count;
    }
    
    // NEW: Returns the number of cards remaining in the deck.
    public int getRemainingCardCount()
    {
        return cards.Count - currentCardIndex;
    }
}