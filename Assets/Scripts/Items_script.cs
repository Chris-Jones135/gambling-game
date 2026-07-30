using UnityEngine;
using System;
using System.Collections.Generic;

public class Items_script : MonoBehaviour
{
    public GameObject Card_Panel;
    public GameObject Card_1;
    public GameObject Card_2;

    public Card_script m_Card_Script;
    public Inven_script m_Inven_Script;
    int Drunk = 0;
    bool YSAdded = false;

    System.Random random = new System.Random();

    void Start()
    {
        Card_Panel.SetActive(false);
    }

    //one card value increased by 1
    public void Marker()
    {
        m_Card_Script.M_PlayerHand.CardRevalue(0,1); // Currently only for the first card in hand, can be very easily changed to work for any card in hand by adding a parameter to the function for the card index.
        Debug.Log("you used the marker on a card in you hand");
        Debug.Log(m_Card_Script.M_PlayerHand.GetHandValue());
        m_Inven_Script.Item = 9999;
    }

    //When you use a item that replaces a card in your hand
    public void Will()
    {
        //to do later
    }

    // a cheap plastic crown: wearing the crown will give Jacks a value of 11, Queens a value of 12 and Kings a value of 13
    public void CheepPlasticCrown()
    {
        m_Card_Script.PlasticJack = 11;
        m_Card_Script.PlasticQueen = 12;
        m_Card_Script.PlasticKing = 13;
        m_Inven_Script.Item = 9999;
    }

    //any value card including 1-21
    public void Bleach()
    {
        //to do as its more complitcated
    }

    //does nothing but if you drink enough you die of alchahol poisoning.
    public void beer()
    {
        Drunk += 1;
        Debug.Log("you drank");
        if (Drunk >= 10)
        {
            //drunk ending
        }
        m_Inven_Script.Item = 9999;

    }
        

    //card with value of 21
    public void YouStupid()
    {
        if (YSAdded)
        {
            return;
        }
        else
        {
            m_Card_Script.NewCard += 1;
            YSAdded = true;
        }
        m_Inven_Script.Item = 9999;

    }

    //one round of re7 21
    public void NeighbourhoodPleasant7()
    {
        //so much work to do for this
    }

    //steal one of the dealers cards so he has one card and you have 3 (33% to miss)
    public void stickyhand()
    {
        int Miss = random.Next(0, 3); // Generates a random number between 0 and 2 (inclusive) for the miss chance

        switch (Miss)
        {
            case 2:
                Debug.Log("Missed. L aim. You need this: https://store.steampowered.com/app/714010/Aimlabs/");
                break;

            default:
                m_Card_Script.M_PlayerHand.AddCardToHand(m_Card_Script.M_DealerHand.GetCard(Miss), m_Card_Script.M_DealerHand.GetCardValue(Miss)); // Add the dealer's card to the player's hand
                m_Card_Script.M_DealerHand.RemoveCard(Miss); // Remove the card from the dealer's hand

                Debug.Log($"Grabbed card {Miss + 1} from the dealer. Big W");

                m_Card_Script.M_PlayerHand.PrintHand("Player"); // Output the player's hand after adding the card
                m_Card_Script.M_DealerHand.PrintHand("Dealer"); // Output the dealer's hand after the card has been removed

                break;
        }
    }

    //Allows you to permanently burn a card for that run
    public void Lighter()
    {
        Card_Panel.SetActive(true);
    }

    public void firstcard()
    {
        Card_Panel.SetActive(false);
        m_Card_Script.M_PlayerHand.RemoveCard(0);
    }
}