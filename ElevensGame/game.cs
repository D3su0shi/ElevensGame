using System;
using System.Collections.Generic;
using System.Linq;

public class Game
{
    // Fields
    private Deck deck;
    private Table table;
    private List<Card> selectedCards = new List<Card>();
    private bool isGameOver;

    // Initializes the deck, table, and game state.
    public Game()
    {
        deck = new Deck();
        table = new Table();
        isGameOver = false;
    }

    // NEW: Public accessor to get the Table instance.
    public Table getTable()
    {
        return table;
    }

    // Shuffles the deck and deals the initial set of cards (up to 9).
    public void startGame()
    {
        deck.shuffle();
        refillTable();
        isGameOver = false;
    }

    // Marks a card as selected by the player.
    public void selectCard(Card card)
    {
        if (!selectedCards.Contains(card))
        {
            selectedCards.Add(card);
        }
    }

    // Removes a previously selected card.
    public void deselectCard(Card card)
    {
        selectedCards.Remove(card);
    }

    // Validates if the selected cards form a legal pair or triple.
    public bool validateSelection()
    {
        if (selectedCards.Count == 2)
        {
            return isSumToEleven(selectedCards);
        }
        else if (selectedCards.Count == 3)
        {
            return isTripleFace(selectedCards);
        }
        return false;
    }

    // Returns true if two selected cards sum to 11.
    public bool isSumToEleven(List<Card> cards)
    {
        return new MoveValidator().isValidPair(cards);
    }

    // Returns true if three selected cards are J, Q, and K.
    public bool isTripleFace(List<Card> cards)
    {
        return new MoveValidator().isValidTriple(cards);
    }

    // Refills the table with new cards until full (maxCards=9) or deck is empty.
    public void refillTable()
    {
        while (table.getCardCount() < 9 && !deck.isEmpty())
        {
            Card? card = deck.dealCard();
            if (card != null)
            {
                table.addCard(card);
            }
        }
    }

    // Checks if all cards have been removed (player wins).
    public bool checkGameWin()
    {
        // Win condition: Deck is empty AND Table is empty
        return deck.isEmpty() && table.getCardCount() == 0;
    }

    // Checks if no valid moves remain (player loses).
    public bool checkGameLose()
    {
        // If the deck is empty and no legal moves exist on the table
        if (deck.isEmpty() && !new MoveValidator().hasLegalMoves(table.getCards()))
        {
            isGameOver = true;
            return true;
        }
        return false;
    }

    // Resets the game with a fresh deck and table.
    public void restartGame()
    {
        deck = new Deck();
        table = new Table();
        selectedCards.Clear();
        isGameOver = false;
        startGame();
    }

    // Displays an error or warning message to the user.
    public void displayWarning(string message)
    {
        Console.WriteLine($"[WARNING]: {message}");
    }

    // Provides visual or textual feedback when actions occur.
    public void updateFeedback()
    {
        // Accessing card count via public method getRemainingCardCount()
        Console.WriteLine($"[FEEDBACK]: Cards on table: {table.getCardCount()}. Deck remaining: {deck.getRemainingCardCount()}");
    }
    
    // Helper method to process a move for testing purposes
    public void processMove()
    {
        if (validateSelection())
        {
            Console.WriteLine($"\n[ACTION]: Valid selection made ({selectedCards.Count} cards). Removing...");
            table.removeCards(selectedCards);
            selectedCards.Clear();
            refillTable();
            Console.WriteLine("Move successful. Table refilled.");
        }
        else
        {
            displayWarning($"Invalid selection (Count: {selectedCards.Count}). Cleared selection.");
            selectedCards.Clear();
        }
        // In a real game, you would update the UI here.
        updateFeedback();
        
        if (checkGameLose())
        {
            Console.WriteLine("\n[GAME OVER]: No legal moves remain and the deck is empty. You lose.");
        }
    }
}