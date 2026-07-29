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
    }

    public void Call()
    {
        int playerScore;

        Debug.Log("Calling");
        M_PlayerHand.AddCard(roundDeck, roundCards);

        playerScore = M_PlayerHand.GetHandValue();

        Debug.Log("You have the cards:");
        for (int i = 0; i < M_PlayerHand.GetHandSize(); i++)
        {
            Debug.Log(M_PlayerHand.GetHand(i));
        }
        Debug.Log("Your current score is: " + playerScore);

        if (playerScore > 21)
        {
            Lose();
        }

        else if (playerScore == 21)
        {
            Debug.Log("NOWAY YOU GOT 21 |_(._.)_| (Absolute Blackjack) YOU ARE BIG WINNER!!!");
            Win();
        }

        else if (M_PlayerHand.GetHandSize() == 5 && playerScore <= 21)
        {
            Debug.Log("You got 5 cards without going over 21. wowee");
            Win();
        }
    }

    public void Stand()
    {
        int dealerScore = M_DealerHand.GetHandValue();

        Debug.Log("Standing");

        Debug.Log("Dealer has the cards:");
        for (int i = 0; i < M_DealerHand.GetHandSize(); i++)
        {
            Debug.Log(M_DealerHand.GetHand(i));
        }
        Debug.Log("Dealer's current score is: " + dealerScore);

        while (dealerScore < 16)
        {
            Debug.Log("Dealer calls:");
            M_DealerHand.AddCard(roundDeck, roundCards);
            dealerScore = M_DealerHand.GetHandValue();

            Debug.Log("Dealer has the cards:");
            for (int i = 0; i < M_DealerHand.GetHandSize(); i++)
            {
                Debug.Log(M_DealerHand.GetHand(i));
            }
            Debug.Log("Dealer's current score is: " + dealerScore);

            if (dealerScore > 21)
            {
                Win();
                return;
            }

            else if (dealerScore == 21)
            {
                Debug.Log("Dealer got 21, automatic loss. L + ratio + no chips + chud times");
                Lose();
                return;
            }

            else if (dealerScore == M_PlayerHand.GetHandValue())
            {
                Tie();
                return;
            }

            else if (dealerScore > M_PlayerHand.GetHandValue())
            {
                Lose();
                return;
            }

            else if (dealerScore < M_PlayerHand.GetHandValue())
            {
                Win();
                return;
            }
        }

        if (dealerScore > M_PlayerHand.GetHandValue())
        {
            Lose();
            return;
        }

        else if (dealerScore < M_PlayerHand.GetHandValue())
        {
            Win();
            return;
        }

        else
        {
            Tie();
            return;
        }
    }

    public void Setup()
    {
        roundDeck = deck;
        roundCards = cardNames;

        for (int i = 0; i < 2; i++)
        {
            M_PlayerHand.AddCard(roundDeck, roundCards);
            M_DealerHand.AddCard(roundDeck, roundCards);
        }

        Debug.Log("You have the cards: " + M_PlayerHand.GetHand(0) + " and " + M_PlayerHand.GetHand(1));
        Debug.Log("Your current score is: " + M_PlayerHand.GetHandValue());
        Debug.Log("Dealer has the cards: " + M_DealerHand.GetHand(0) + " and a hidden card");
    }

    public void Win()
    {
        Debug.Log("You win! This is good news Mark");

        Reset();

        M_Moneymanager.bet *= 2;
        M_Moneymanager.PlayerChips += M_Moneymanager.bet;
        M_Moneymanager.Start();
    }

    public void Lose()
    {
        Debug.Log("You lose, Womp Womp");

        Reset();

        M_Moneymanager.PlayerChips -= M_Moneymanager.bet;
        M_Moneymanager.Start();
    }

    public void Tie()
    {
        Debug.Log("You tied, no chip for you");

        Reset();

        M_Moneymanager.Start();
    }
}