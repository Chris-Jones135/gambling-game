using UnityEngine;
using System;
using System.Collections.Generic;

public class Hand_Class : MonoBehaviour
{
    // creates a blank hand for the player with 5 spaces as that is the max hand available without going over 21
    private string[] CardsInHand = { "N/A", "N/A", "N/A", "N/A", "N/A" };
    // creates a variable to hold the current position in the hand for adding cards
    private int BackPointer = 0;
    //creates a copy of just the scores in the hand for items later.
    private int[] HandValues = { 0, 0, 0, 0, 0 };
    // creates a variable to hold the total value of the hand
    private int HandValue = 0;
    System.Random random = new System.Random();

    public void AddCard(List<List<int>> deck, List<List<string>> cardNames)
    {
        string CardSuit = "";
        int Suit = random.Next(0, 4); //Select a random suit from the deck

        switch (Suit)
        {             
            case 0:
                CardSuit = "Hearts";
                break;

            case 1:
                CardSuit = "Diamonds";
                break;

            case 2:
                CardSuit = "Clubs";
                break;

            case 3:
                CardSuit = "Spades";
                break;

            default:
                CardSuit = "Speeve"; // Because why not
                break;
        }

        int Value = random.Next(0, deck[Suit].Count); // Select a random card from the deck based on the suit and the cards left in that suit

        if (cardNames[Suit][Value].Contains("Ace"))
        {
            CardsInHand[BackPointer] = cardNames[Suit][Value] + " of " + CardSuit;
            if (HandValue + 11 > 21)
            {
                HandValues[BackPointer] = 1;
            }
            else
            {
                HandValues[BackPointer] = deck[Suit][Value];
            }
        }

        else
        {
            CardsInHand[BackPointer] = cardNames[Suit][Value] + " of " + CardSuit;
            HandValues[BackPointer] = deck[Suit][Value];
        }

        deck[Suit].RemoveAt(Value); // Remove the card from the deck so it can't be drawn again
        cardNames[Suit].RemoveAt(Value); // Remove the card name from the deck so it can't be drawn again

        HandValue += HandValues[BackPointer];
        BackPointer++;
    }

    public void ResetHand()
    {
        CardsInHand = new string[] { "N/A", "N/A", "N/A", "N/A", "N/A" };
        BackPointer = 0;
        HandValues = new int[] { 0, 0, 0, 0, 0 };
        HandValue = 0;
    }

    public string GetHand(int i)
    {
        return CardsInHand[i];
    }

    public int GetHandValue()
    {
        return HandValue;
    }

    public int GetHandSize()
    {
        return BackPointer;
    }
}
