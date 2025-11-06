 Console.WriteLine("--- Elevens Game Class Integration Test ---");
        
        // 1. Card/Deck Sanity Check
        Card testCard = new Card("Queen", "Hearts", 10);
        Console.WriteLine($"\n1. Card Test: {testCard.ToString()} (Value: {testCard.getValue()})"); 
        
        Deck deck = new Deck();
        Card? firstCard = deck.dealCard(); 
        Console.WriteLine($"Initial Deal (1/52): {firstCard?.ToString()}"); 

        Console.WriteLine("\n--- Table, Validator, and Game Test ---");

        // 2. Table Class Test
        Table testTable = new Table();
        testTable.addCard(new Card("4", "Hearts", 4));
        testTable.addCard(new Card("7", "Clubs", 7));
        Console.WriteLine($"\n2. Table Test: Card count = {testTable.getCardCount()} (Expected 2)");
        
        // 3. MoveValidator Class Test
        MoveValidator validator = new MoveValidator();
        Card five = new Card("5", "Spades", 5);
        Card six = new Card("6", "Diamonds", 6);
        Card jack = new Card("Jack", "Hearts", 10);
        Card queen = new Card("Queen", "Clubs", 10);
        Card king = new Card("King", "Diamonds", 10);

        Console.WriteLine("\n3. MoveValidator Test:");
        
        // Valid Pair Test (5 + 6 = 11)
        List<Card> pair = new List<Card> { five, six };
        Console.WriteLine($"  Valid Pair (5, 6) check: {validator.isValidPair(pair)} (Expected True)");
        
        // Valid Triple Test (J, Q, K)
        List<Card> triple = new List<Card> { jack, queen, king };
        Console.WriteLine($"  Valid Triple (J, Q, K) check: {validator.isValidTriple(triple)} (Expected True)");
        
        // Has Legal Moves Test
        List<Card> legalTable = new List<Card> { five, six, new Card("2", "C", 2) };
        Console.WriteLine($"  Has Legal Moves (5, 6, 2) check: {validator.hasLegalMoves(legalTable)} (Expected True)");

        // 4. Game Class Test
        Console.WriteLine("\n4. Game Initialization and Move Test:");
        Game game = new Game();
        game.startGame();
        
        // Use getTable() accessor instead of direct field access
        Table currentTable = game.getTable(); 
        
        Console.WriteLine($"  Game started. Table has {currentTable.getCards().Count} cards.");
        
        // Find cards to make a legal move for demonstration
        Card? c_jack = currentTable.getCards().FirstOrDefault(c => c.getRank() == "Jack");
        Card? c_queen = currentTable.getCards().FirstOrDefault(c => c.getRank() == "Queen");
        Card? c_king = currentTable.getCards().FirstOrDefault(c => c.getRank() == "King");
        
        if (c_jack != null && c_queen != null && c_king != null)
        {
            Console.WriteLine("\n  Attempting to process a valid J-Q-K triple...");
            game.selectCard(c_jack);
            game.selectCard(c_queen);
            game.selectCard(c_king);
            game.processMove();
        }
        else
        {
            Console.WriteLine("\n  A J-Q-K set was not found on the initial table. Testing an invalid move.");
            
            // Invalid move test (select two cards)
            if (currentTable.getCards().Count >= 2)
            {
                game.selectCard(currentTable.getCards()[0]);
                game.selectCard(currentTable.getCards()[1]);
                game.processMove(); // Should print WARNING
            }
        }

        // Test restart
        game.restartGame();
        Console.WriteLine($"\n  Game restarted. Table now has {game.getTable().getCards().Count} cards.");
   