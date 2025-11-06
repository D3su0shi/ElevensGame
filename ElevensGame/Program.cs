using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Helper method to display the cards on the table with their corresponding index number.
    static void DisplayTable(Table table)
    {
        Console.WriteLine("\n==============================================");
        Console.WriteLine("                CARDS ON TABLE                ");
        Console.WriteLine("==============================================");
        
        List<Card> cards = table.getCards();
        if (cards.Count == 0)
        {
            Console.WriteLine("    The table is empty! You're close to winning!");
        }
        else
        {
            for (int i = 0; i < cards.Count; i++)
            {
                // Display 1-based index for the user
                Console.WriteLine($"[{i + 1}]: {cards[i].ToString()} (Value: {cards[i].getValue()})");
            }
        }
        Console.WriteLine("==============================================");
    }

    // Main game execution method.
    static void Main(string[] args)
    {
        Game game = new Game();
        game.startGame();

        Console.WriteLine("--- Welcome to the Elevens Console Game! ---");
        Console.WriteLine("Instructions:");
        Console.WriteLine("1. Clear the table by finding pairs that sum to 11 (A-10) or sets of J, Q, K.");
        Console.WriteLine("2. Enter the index number (1-9) of the cards you wish to select, separated by spaces.");
        Console.WriteLine("   Example: To select card 2 and card 5, type: 2 5");
        Console.WriteLine("   To exit the game, type: quit\n");
        
        // Main game loop
        while (!game.checkGameWin() && !game.checkGameLose())
        {
            DisplayTable(game.getTable());
            game.updateFeedback(); // Show deck/table count

            Console.Write("\nEnter selection (e.g., 1 5 9): ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input) || input == "quit")
            {
                break;
            }

            // --- Input Processing ---
            List<Card> currentTableCards = game.getTable().getCards();
            
            // Parse indices from input string
            List<int> selectedIndices = new List<int>();
            try
            {
                selectedIndices = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(s => int.Parse(s))
                                       .ToList();
            }
            catch (FormatException)
            {
                game.displayWarning("Invalid input format. Please enter numbers separated by spaces.");
                continue;
            }
            
            // Select the cards in the Game object
            bool selectionFailed = false;
            foreach (int index in selectedIndices.Distinct())
            {
                if (index >= 1 && index <= currentTableCards.Count)
                {
                    game.selectCard(currentTableCards[index - 1]);
                }
                else
                {
                    game.displayWarning($"Invalid card number: {index}. Selection cleared.");
                    selectionFailed = true;
                    break;
                }
            }

            // If selection failed, the loop continues and the game selection is implicitly cleared/overwritten on the next valid selection attempt.
            if (!selectionFailed)
            {
                game.processMove(); 
            }
        }
        
        // --- End Game Logic ---
        Console.WriteLine("\n==============================================");
        if (game.checkGameWin())
        {
            Console.WriteLine("CONGRATULATIONS! YOU CLEARED THE DECK AND THE TABLE! YOU WIN!");
        }
        else if (game.checkGameLose())
        {
            // CRITICAL FIX: Display the final, stuck table state before the Game Over message.
            DisplayTable(game.getTable()); 
            Console.WriteLine("GAME OVER: No legal moves left on the table. You lose.");
        }
        else
        {
            Console.WriteLine("Game quit by user. Thank you for playing!");
        }
        Console.WriteLine("==============================================");
    }
}