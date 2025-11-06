Console.WriteLine("--- Card and Deck Function Test ---");
        
        // Test Card initialization
        Card testCard = new Card("Queen", "Hearts", 10);
        Console.WriteLine($"\n1. Card Test: {testCard.ToString()} (Value: {testCard.getValue()})"); 
        if (testCard.getValue() == 10)
        {
            Console.WriteLine("✅ Card value check passed.");
        }

        // Test Deck creation and dealing
        Console.WriteLine("\n2. Deck Creation and Deal Test");
        Deck deck = new Deck();
        
        // Deal first card (should be Ace of Clubs if unshuffled)
        Card? firstCard = deck.dealCard(); // Use Card? for nullable result
        Console.WriteLine($"Initial Deal (1/52): {firstCard?.ToString()}"); 
        
        // Test Shuffling
        Console.WriteLine("\n3. Deck Shuffle Test");
        deck = new Deck(); // Reinitialize
        deck.shuffle();
        Card? shuffledCard = deck.dealCard(); // Use Card? for nullable result
        Console.WriteLine($"Shuffled Deal (1/52): {shuffledCard?.ToString()} (Should be random)"); 

        // Test isEmpty and dealCard fully
        Console.WriteLine("\n4. Deck Emptiness Test");
        
        // Deal the remaining 51 cards
        for (int i = 0; i < 51; i++) 
        {
            deck.dealCard();
        }
        
        Console.WriteLine($"Is deck empty before final deal? {deck.isEmpty()}"); 
        
        // Attempt to deal one more (should return null)
        Card? extraCard = deck.dealCard(); // Use Card? for nullable result
        
        if (deck.isEmpty() && extraCard == null)
        {
            Console.WriteLine("✅ Deck empty check passed (All cards dealt, next deal is null).");
        }
        else
        {
            Console.WriteLine("❌ Deck empty check failed.");
        }

        Console.WriteLine("\n--- Test Complete ---");