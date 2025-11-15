# Compiling and Running the Game

Assuming you have the .NET SDK installed, you can easily compile and run this game from your terminal or command prompt.
1. Save Files and Create Project
Save the files: Ensure all the provided files (Program.cs, Game.cs, Deck.cs, Table.cs, Card.cs, and MoveValidator.cs) are saved in the same directory.
Create a Project: In that directory, create a new C# console project using the .NET CLI:
dotnet new console --name ElevensGame
This creates the project file (ElevensGame.csproj) and a new Program.cs (which you can delete or overwrite with your provided Program.cs content).
Ensure correct files: Make sure the directory contains your project file (.csproj) and all six of your .cs files.
2. Compile and Run
Compile the code: Navigate to the project directory in your terminal and compile the application:
dotnet build
This command compiles all the .cs files into an executable.
Run the game: Execute the compiled application:
dotnet run

The game will then start in your console, displaying the instructions and the initial table of cards.

Game Summary

The Elevens Console Game is a card-clearing game based on the rules of Elevens.
Objective: Clear the table of cards by making legal moves and empty the entire deck.
Legal Moves:
Select two non-face cards (Ace-10) whose numerical values sum to 11.
Select a set of three cards consisting of a Jack, a Queen, and a King (regardless of suit).
Gameplay Flow: The game starts with up to 9 cards on the table. When a legal move is made, the selected cards are removed, and the table is immediately refilled from the deck until it has 9 cards or the deck is empty.
Win/Loss Conditions:
Win: The deck is empty and the table is empty.
Loss: The deck is not empty, but there are no legal moves remaining on the cards currently on the table.

# erros , bugs and challenges :
 Casing and Type Mismatch Errors
The first set of errors stemmed from language syntax compatibility. The solution was straightforward: every instance of toString() was corrected to use the proper C# convention, ToString(), ensuring the method correctly overrode the base object method and was accessible throughout the application.
Class Access and Protection Level Violations
As the codebase was segmented into separate files, protection level errors (CS0122) arose from attempting to access private fields directly from external classes. Specifically, the private field Deck.cards was inaccessible when calculating the remaining deck size in the Game class, and the private field Game.table was inaccessible in the Program.cs test runner. To uphold encapsulation principles, I did not change the field access level. Instead, I implemented public accessor methods. For the Deck, I introduced getRemainingCardCount() to safely expose the card count. For the Game class, I introduced getTable() to provide read-only access to the Table instance necessary for display and testing, successfully resolving all access control violations.
Nullability and Initialization Warnings
I addressed several warnings related to C#’s non-nullable reference types. This was resolved by updating the method's return type to use the nullable reference type syntax, Card?.
Critical Game Over Logic Failure
A significant bug was identified where the game would not terminate when the board was stuck (i.e., no legal moves possible), provided the deck was not yet empty. The player would be continuously prompted for input, even though no valid action could be taken. The Game.checkGameLose() method was initially too restrictive, relying on the deck being empty as a precondition for checking for a loss. The fix involved modifying checkGameLose() to simply return true if no legal moves were available on the table, regardless of how many cards remained in the deck. This correctly signalled the loss condition to the main loop in Program.cs.



 
 ---------------------
        Card
---------------------
- rank : String
- suit : String
- value : int
---------------------
+ Card(rank : String, suit : String, value : int)
    → Initializes a new card with a rank, suit, and value.
+ getRank() : String
    → Returns the rank of the card.
+ getSuit() : String
    → Returns the suit of the card.
+ getValue() : int
    → Returns the numerical value of the card.
+ toString() : String
    → Returns a string representation of the card.
---------------------


---------------------
        Deck
---------------------
- cards : List<Card>
- currentCardIndex : int
---------------------
+ Deck()
    → Creates a standard 52-card deck and initializes it.
+ shuffle() : void
    → Randomly rearranges the cards in the deck.
+ dealCard() : Card
    → Deals and returns the next card from the deck.
+ isEmpty() : bool
    → Returns true if no cards remain in the deck.
---------------------


---------------------
        Table
---------------------
- cardsOnTable : List<Card>
- maxCards : int = 9
---------------------
+ addCard(card : Card) : void
    → Adds a card to the table if space is available.
+ removeCards(selected : List<Card>) : void
    → Removes the specified cards from the table.
+ getCards() : List<Card>
    → Returns all cards currently on the table.
+ getCardCount() : int
    → Returns the number of cards currently on the table.
---------------------


---------------------
        MoveValidator
---------------------
+ isValidPair(cards : List<Card>) : bool
    → Checks if two selected cards sum to 11.
+ isValidTriple(cards : List<Card>) : bool
    → Checks if three selected cards are Jack, Queen, and King.
+ hasLegalMoves(tableCards : List<Card>) : bool
    → Determines if any valid pair or triple still exists on the table.
---------------------


---------------------
        Game
---------------------
- deck : Deck
- table : Table
- selectedCards : List<Card>
- isGameOver : bool
---------------------
+ Game()
    → Initializes the deck, table, and game state.
+ startGame() : void
    → Shuffles the deck and deals the initial set of cards.
+ selectCard(card : Card) : void
    → Marks a card as selected by the player.
+ deselectCard(card : Card) : void
    → Removes a previously selected card.
+ validateSelection() : bool
    → Validates if the selected cards form a legal pair or triple.
+ isSumToEleven(cards : List<Card>) : bool
    → Returns true if two selected cards sum to 11.
+ isTripleFace(cards : List<Card>) : bool
    → Returns true if three selected cards are J, Q, and K.
+ refillTable() : void
    → Refills the table with new cards until full or deck is empty.
+ checkGameWin() : bool
    → Checks if all cards have been removed (player wins).
+ checkGameLose() : bool
    → Checks if no valid moves remain (player loses).
+ restartGame() : void
    → Resets the game with a fresh deck and table.
+ displayWarning(message : String) : void
    → Displays an error or warning message to the user.
+ updateFeedback() : void
    → Provides visual or textual feedback when actions occur.
---------------------

Elevens (Project 1) - 1st submission
    - Class design for card and deck with basic test in program


Elevens (Project 1) - 2nd submission
    - game , moveValidator and table implementation 


Elevens (Project 1) - the final submission
    - actual game logic and run test
    - bug where game doesnt end when no legal moves exist fixed
    - diplays table showing that there are no valid legal moves left before quiting the game



