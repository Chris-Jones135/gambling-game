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
        } // Check which suit was selected to draw the card from

        int Value = random.Next(0, deck[Suit].Count); // Select a random card from the deck based on the suit and the cards left in that suit

        if (cardNames[Suit][Value].Contains("Ace"))
        {
            CardsInHand[BackPointer] = cardNames[Suit][Value] + " of " + CardSuit;
            if (HandValue + deck[Suit][Value] > 21)
            {
                HandValues[BackPointer] = 1;
            }
            else
            {
                HandValues[BackPointer] = deck[Suit][Value];
            }
        } // If the drawn card is an Ace, check if adding 11 would go over 21, if so add 1 instead to keep the player from losing immediately

        else
        {
            CardsInHand[BackPointer] = cardNames[Suit][Value] + " of " + CardSuit;
            HandValues[BackPointer] = deck[Suit][Value];
        } // If the drawn card is anything else, just add the value of the card to the hand value and move on

        deck[Suit].RemoveAt(Value); // Remove the card from the deck so it can't be drawn again
        cardNames[Suit].RemoveAt(Value); // Remove the card name from the deck so it can't be drawn again

        HandValue += HandValues[BackPointer]; // Increment the total hand value by the value of the card just drawn
        BackPointer++; // Increment the back pointer to the next available space in the hand
    }

    public void ResetHand()
    {
        CardsInHand = new string[] { "N/A", "N/A", "N/A", "N/A", "N/A" };
        BackPointer = 0;
        HandValues = new int[] { 0, 0, 0, 0, 0 };
        HandValue = 0;
    } // Resets the hand to its initial state, clearing all cards and values

    public string GetCard(int i)
    {
        return CardsInHand[i];
    } // Gets a specific card from the hand based on the index provided

    public int GetCardValue(int i)
    {
        return HandValues[i];
    } // Gets the value of a specific card in the hand based on the index provided

    public int GetHandValue()
    {
        return HandValue;
    } // Get the current total value of the hand, useful for determining if the player has gone over 21 or not

    public int GetHandSize()
    {
        return BackPointer;
    } // Gets the value of the back pointer, useful for determining how many cards are in the hand at any given time

    public void CalcHandValue()
    {
        HandValue = 0;
        for (int i = 0; i < BackPointer; i++)
        {
            HandValue += HandValues[i];
        }
    } // Recalculates the total value of the hand, incase any cards are removed or changed during the round

    public void CardRevalue(int index, int change)
    {
        HandValues[index] += change;
        CalcHandValue();
    }

    public void RemoveCard(int index)
    {
        if (BackPointer != 0 && index < BackPointer)
        {
            if (index == BackPointer - 1)
            {
                CardsInHand[index] = "N/A";
                HandValues[index] = 0;
                BackPointer--;
            } // If the card being removed is the last card in the hand, just set it to N/A and decrement the back pointer

            else
            {
                for (int i = index; i < BackPointer; i++)
                {
                    CardsInHand[i] = CardsInHand[i + 1];
                    HandValues[i] = HandValues[i + 1];
                } // Removes the card at the specified index from the hand and shifts all subsequent cards down to fill the gap
                BackPointer--;
            }

            CalcHandValue(); // Recalculates the total value of the hand after a card has been removed
        }
    } // Removes a card from the hand at the specified index, shifting all subsequent cards down to fill the gap and decrementing the back pointer

    public void AddCardToHand(string cardName, int cardValue)
    {
        CardsInHand[BackPointer] = cardName;
        HandValues[BackPointer] = cardValue;
        HandValue += cardValue;
        BackPointer++;

        CalcHandValue(); // Recalculates the total value of the hand after a card has been added
    } // Adds a specific card to the hand, useful for testing or adding cards from a different source than the deck

    public void PrintHand(string player)
    {
        string handString = player + "'s Current Hand: ";
        for (int i = 0; i < BackPointer; i++)
        {
            handString += CardsInHand[i] + ", ";
        }
        Debug.Log(handString);
        Debug.Log("Value: " + HandValue);
    } // Prints the current hand to the console, useful for debugging and testing
}