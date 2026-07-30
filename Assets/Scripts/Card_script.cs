using UnityEngine;
using System;
using System.Collections.Generic;

public class Card_script : MonoBehaviour
{
    private string CardSuit;
    private string CardValue;
    private string CurrentCard;
    public int PlasticJack = 10;
    public int PlasticQueen = 10;
    public int PlasticKing = 10;
    public int NewCard = 13;
    public bool Standing = false;
    public MoneyManager M_Moneymanager;
    public Hand_Class M_PlayerHand;
    public Hand_Class M_DealerHand;

    private List<List<int>> deck;
    private List<List<string>> cardNames;
    private List<List<int>> roundDeck;
    private List<List<string>> roundCards;

    public void Start()
    {
        deck = new List<List<int>>()
        {
            new List<int>() { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, PlasticJack, PlasticQueen, PlasticKing }, // Hearts
            new List<int>() { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, PlasticJack, PlasticQueen, PlasticKing }, // Diamonds
            new List<int>() { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, PlasticJack, PlasticQueen, PlasticKing }, // Clubs
            new List<int>() { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, PlasticJack, PlasticQueen, PlasticKing } // Spades
        }; // Creates the deck of cards for all the suits

        cardNames = new List<List<string>>()
        {
            new List<string>() {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"}, // Hearts
            new List<string>() {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"}, // Diamonds
            new List<string>() {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"}, // Clubs
            new List<string>() {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"} // Spades
        }; // Card names to use for the display names and for checking to see if a card is an Ace or not
    }

    public void Reset()
    {
        M_PlayerHand.ResetHand();
        M_DealerHand.ResetHand();
    } // Resets the hands of the player and dealer for a new round

    public void Call()
    {
        int playerScore;

        Debug.Log("Calling");
        M_PlayerHand.AddCard(roundDeck, roundCards); // Adds a new card to the player's hand

        playerScore = M_PlayerHand.GetHandValue(); // Get the player's current score

        M_PlayerHand.PrintHand("Player"); // Prints the player's hand to the console

        PlayerCheck(playerScore); // Checks the player's score to see if drawing a new card has caused an automatic win or loss condition
    }

    public void Stand()
    {
        int dealerScore = M_DealerHand.GetHandValue(); // Get the dealer's current score

        Debug.Log("Standing");

        M_DealerHand.PrintHand("Dealer"); // Prints the dealer's hand to the console

        while (dealerScore < 16) // While the dealer's score is less than 16, they will continue to call for cards
        {
            Debug.Log("Dealer calls:");
            M_DealerHand.AddCard(roundDeck, roundCards); // Adds a new card to the dealer's hand
            dealerScore = M_DealerHand.GetHandValue(); // Get the dealer's current score after adding a new card

            M_DealerHand.PrintHand("Dealer"); // Prints the dealer's hand to the console

            if (dealerScore > 21)
            {
                Win();
                return;
            } // Automatic win condition for if the dealer goes over 21

            else if (dealerScore == 21)
            {
                Debug.Log("Dealer got 21, automatic loss. L + ratio + no chips + chud times");
                Lose();
                return;
            } // Automatic loss condition for if the dealer gets 21`

            else if (dealerScore > M_PlayerHand.GetHandValue())
            {
                Lose();
                return;
            } // If the dealer's score ever overtakes the player's, the player loses
        }

        if (dealerScore > M_PlayerHand.GetHandValue())
        {
            Lose();
            return;
        } // If the dealer's score is greater than the player's, the player loses (Condition for if no card is drawn)

        else if (dealerScore < M_PlayerHand.GetHandValue())
        {
            Win();
            return;
        } // If the dealer's score is less than the player's after they no longer want to draw cards, the player wins

        else
        {
            Tie();
            return;
        } // If the dealer's score is equal to the player's after they no longer want to draw cards, the game is a tie
    }

    public void Setup()
    {
        roundDeck = deck; // A deck of cards for the round, so the main deck doesnt get altered when cards are drawn
        roundCards = cardNames; // The card names for the round, so the main card names dont get altered when cards are drawn

        for (int i = 0; i < 2; i++)
        {
            M_PlayerHand.AddCard(roundDeck, roundCards);
            M_DealerHand.AddCard(roundDeck, roundCards);
        } // Gives the player and dealer 2 cards each at the start of the round

        M_PlayerHand.PrintHand("Player"); // Prints the player's hand to the console
        Debug.Log("Dealer has the cards: " + M_DealerHand.GetCard(0) + " and a hidden card"); // Outputs what would be visable to the player in a real game of blackjack, the dealer's second card is hidden until the player stands

        PlayerCheck(M_PlayerHand.GetHandValue()); // Checks the player's score to see if they drew into a 21 immediately
    }

    public void Win()
    {
        Debug.Log("You win! This is good news Mark");

        Reset();

        M_Moneymanager.bet *= 2;
        M_Moneymanager.PlayerChips += M_Moneymanager.bet;
        M_Moneymanager.Start();
    } // Upon winning a round, player and dealer hands are reset, the player's bet is doubled and added to their chips, and the game is restarted

    public void Lose()
    {
        Debug.Log("You lose, Womp Womp");

        Reset();

        M_Moneymanager.PlayerChips -= M_Moneymanager.bet;
        M_Moneymanager.Start();
    } // Upon losing a round, player and dealer hands are reset, the player's bet is subtracted from their chips, and the game is restarted

    public void Tie()
    {
        Debug.Log("You tied, no chip for you");

        Reset();

        M_Moneymanager.Start();
    } // Upon tying a round, player and dealer hands are reset, the player's chips remain the same, and the game is restarted

    public void PlayerCheck(int playerScore)
    {
        if (playerScore > 21)
        {
            Lose();
        } // Condition for if the player goes over 21, they lose

        else if (playerScore == 21)
        {
            Debug.Log("NOWAY YOU GOT 21 |_(._.)_| (Absolute Blackjack) YOU ARE BIG WINNER!!!");
            Win();
        } // Automatic win condition for if the player gets 21

        else if (M_PlayerHand.GetHandSize() == 5 && playerScore <= 21)
        {
            Debug.Log("You got 5 cards without going over 21. wowee");
            Win();
        } // Automatic win condition for if the player gets 5 cards without going over 21
    }
}