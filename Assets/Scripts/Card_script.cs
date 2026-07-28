using UnityEngine;

public class Card_script : MonoBehaviour
{
    private string CardSuit;
    private string CardValue;
    private string CurrentCard;
    public int PlasticJack = 10;
    public int PlasticQueen = 10;
    public int PlasticKing = 10;
    public int NewCard = 13;
    private bool AceReduced = false;
    public bool Standing = false;
    public MoneyManager M_Moneymanager;

    // creates a blank hand for the player with 5 spaces as that is the max hand available without going over 21
    public string[] Cardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};
    //creates a copy of just the scores in the hand for items later.
    public int[] HandValues = { 0, 0, 0, 0, 0 };

    // variable which holds current hand value
    public int CurrentScore;
    // this does the same as the player just for the dealer
    public string[] DealerCardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};

    public int[] DealerHandValues = { 0, 0, 0, 0, 0 };

    public int DealerCurrentScore;



    public void start()
    {

    }

    int Cardmaker()
    {
        //just stops the code being a bitch about returned values sorry Andrew
        return 1;
    }

    public void Reset()
    {
        
    }

    public void call()
    {

    }

    public void Stand()
    {

    }
}