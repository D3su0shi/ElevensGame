using System;
using System.Collections.Generic;
using System.Linq;

public class Table
{
    // Fields
    private List<Card> cardsOnTable = new List<Card>();
    private int maxCards = 9;

    // Initializes card list
    public Table()
    {
        // List initialized inline
    }

    // Adds a card to the table if space is available.
    public void addCard(Card? card)
    {
        if (card != null && cardsOnTable.Count < maxCards)
        {
            cardsOnTable.Add(card);
        }
    }

    // Removes the specified cards from the table.
    public void removeCards(List<Card> selected)
    {
        foreach (var card in selected)
        {
            cardsOnTable.Remove(card);
        }
    }

    // Returns all cards currently on the table.
    public List<Card> getCards()
    {
        return cardsOnTable;
    }

    // Returns the number of cards currently on the table.
    public int getCardCount()
    {
        return cardsOnTable.Count;
    }
}