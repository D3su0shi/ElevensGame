using System;
using System.Collections.Generic;


/// Represents a single playing card.

public class Card
{
    // Fields
    private string rank;
    private string suit;
    private int value;

    // Static properties for deck building
    public static string[] Suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
    public static string[] Ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

    
    /// Initializes a new card.
    
    public Card(string rank, string suit, int value)
    {
        this.rank = rank;
        this.suit = suit;
        this.value = value;
    }

    
    /// Returns the rank of the card.
    
    public string getRank()
    {
        return rank;
    }

    
    /// Returns the suit of the card.
    
    public string getSuit()
    {
        return suit;
    }

    
    /// Returns the numerical value of the card.
    public int getValue()
    {
        return value;
    }

    /// Returns a string representation of the card.
    public override string ToString()
    {
        return $"{rank} of {suit}";
    }
}