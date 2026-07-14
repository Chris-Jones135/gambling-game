using UnityEngine;

public class Card_script : MonoBehaviour
{
    private string CardSuit;
    private string CardValue;
    private string CurrentCard;
    private bool AceReduced = false;
    public bool Standing = false;
    public MoneyManager M_Moneymanager;

    // creates a blank hand for the player with 15 spaces as that is the max hand available without going over 21
    private string[] Cardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};
    // variable which holds current hand value
    private int CurrentScore;
    // this does the same as the player just for the dealer
    private string[] DealerCardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};
    private int DealerCurrentScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    // 
    public void start()
    {
        //WHY THE FUCK IS THIS LIKE THIS, sets up Scores for both the dealer and the player, and tells the player what Cards the player has and the first Card in the dealers hand
        CurrentScore += CurrentScore = Cardmaker(Cardsinhand);
        CurrentScore += CurrentScore = Cardmaker(Cardsinhand);
        //done twice due to looping in the function not working.
        DealerCurrentScore += DealerCurrentScore = Cardmaker(DealerCardsinhand);
        DealerCurrentScore += DealerCurrentScore = Cardmaker(DealerCardsinhand);
        Debug.Log("you have " + Cardsinhand[0] + " " + Cardsinhand[1] + " " + Cardsinhand[2] + " " + Cardsinhand[3] + " " + Cardsinhand[4]);
        Debug.Log(CurrentScore);
        Debug.Log("the dealer has a " + DealerCardsinhand[0]);
    }

    int Cardmaker(string[] HandCard)
    {
        int Score = 0;

        // random variable which allows for the Card value to be chosen between 1 and 13 if 1 the Card is an ace
        int Card = Random.Range(1, 13);

        // randomised the suit of the Card so that it isnt just numbers
        int Suit = Random.Range(0, 3);
        switch (Suit)
        {
            case 0:
                CardSuit = "hearts";
                break;

            case 1:
                CardSuit = "diamonds";
                break;

            case 2:
                CardSuit = "spades";
                break;

            case 3:
                CardSuit = "clubs";
                break;

            //We am speeve
            default:
                CardSuit = "speeve";
                break;
        }

        //checks for specialised Cards so that it can disply the Cards properly in hand
        switch (Card)
        {
            // reduces ace when pulled if score goes over 21
            case 1:
                CardValue = "Ace";
                if (Score + 11 > 21)
                {
                    Score += 1;
                    AceReduced = true;
                }
                else
                {
                    Score += 11;
                }
                break;

            case 11:
                CardValue = "Jack";
                Score += 10;
                break;

            case 12:
                CardValue = "Queen";
                 Score += 10;
                 break;

            case 13:
                CardValue = "King";
                Score += 10;
                break;

            default:
                CardValue = Card.ToString();
                Score += Card;
                break;
        }

        

        //create the tag for the Card to hold within the players hand.(will help with the prefabs for Cards later)
        CurrentCard = CardValue + " of " + CardSuit;
        // go my chud i, loops through hand to diaplay it fully for the player
        for (int i = 0; i < 5; i++)
        {
            if (HandCard[i] == "N/A")
            {
                HandCard[i] = CurrentCard;
                i = 5;
            }
        }

        if (CurrentScore == 21)
        {
            Debug.Log("I win YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
            //resets hand to blank
            for (int i = 0; i < 5; i++)
            {
                Cardsinhand[i] = "N/A";
                DealerCardsinhand[i] = "N/A";
                CurrentScore = 0;
                DealerCurrentScore = 0;
                AceReduced = false;
                Standing = false;
            }
            //doubles the bet amount you placed and gives it to you through the money manager script.
            M_Moneymanager.bet = M_Moneymanager.bet * 2;
            M_Moneymanager.playersChips = M_Moneymanager.bet;
            M_Moneymanager.Start();

        }
        return Score;
    }

    public void call()
    {
        Debug.Log("Prick.");
        //checks for all losing conditions if none are met gives the player a new card
        if (Cardsinhand[4] == "N/A" && CurrentScore < 21 && Standing == false)
        {
            CurrentScore += CurrentScore = Cardmaker(Cardsinhand);
        }

        // checks list for an ace in hand as if there is an ace it can change it to low ace.
        for (int i = 0; i < 5; i++)
        {
            if (Cardsinhand[i] == "Ace of hearts" && CurrentScore > 21 && AceReduced == false || Cardsinhand[i] == "Ace of diamonds" && CurrentScore > 21 && AceReduced == false || Cardsinhand[i] == "Ace of spades" && CurrentScore > 21 && AceReduced == false || Cardsinhand[i] == "Ace of clubs" && CurrentScore > 21 && AceReduced == false)
            {
                CurrentScore = CurrentScore - 10;
                AceReduced = true;
            }
        }

        Debug.Log("you have " + Cardsinhand[0] + " " + Cardsinhand[1] + " " + Cardsinhand[2] + " " + Cardsinhand[3] + " " + Cardsinhand[4]);
        Debug.Log(CurrentScore);

        if (CurrentScore > 21)
        {
            Debug.Log("you have busted and failed your game");
            for (int i = 0; i < 5; i++)
            {
                Cardsinhand[i] = "N/A";
                DealerCardsinhand[i] = "N/A";
                CurrentScore = 0;
                DealerCurrentScore = 0;
                AceReduced = false;
                Standing = false;
            }
            M_Moneymanager.playersChips -= M_Moneymanager.bet;
            M_Moneymanager.Start();
        }

        if (CurrentScore <= 21 && Cardsinhand[4] != "N/A")
        {
            Debug.Log("you got a 5 Card hand well done");

            for (int i = 0; i < 5; i++)
            {
                Cardsinhand[i] = "N/A";
                DealerCardsinhand[i] = "N/A";
                CurrentScore = 0;
                DealerCurrentScore = 0;
                AceReduced = false;
                Standing = false;
            }
            M_Moneymanager.bet = M_Moneymanager.bet * 2;
            M_Moneymanager.playersChips = M_Moneymanager.bet;
            M_Moneymanager.Start();
        }
    }

    public void Stand()
    {
        AceReduced = false;
        Debug.Log(DealerCardsinhand[0] + " " + DealerCardsinhand[1]);

        if (DealerCurrentScore < 16)
        {
            DealerCurrentScore += DealerCurrentScore = Cardmaker(DealerCardsinhand);
            Debug.Log("the dealers hand is " + DealerCardsinhand[0] + " " + DealerCardsinhand[1] + " " + DealerCardsinhand[2] + " " + DealerCardsinhand[3] + " " + DealerCardsinhand[4]);
            Debug.Log("Dealer Score: " + DealerCurrentScore);
            // checks list for an ace in dealers hand as if there is an ace it can change it to low ace.
            for (int i = 0; i < 5; i++)
            {
                if (DealerCardsinhand[i] == "Ace of hearts" && DealerCurrentScore > 21 && AceReduced == false || DealerCardsinhand[i] == "Ace of diamonds" && DealerCurrentScore > 21 && AceReduced == false || DealerCardsinhand[i] == "Ace of spades" && DealerCurrentScore > 21 && AceReduced == false || DealerCardsinhand[i] == "Ace of clubs" && DealerCurrentScore > 21 && AceReduced == false)
                {
                    DealerCurrentScore = DealerCurrentScore - 10;
                    AceReduced = true;
                }
            }
            Stand();
        }
        else
        {
            if (DealerCurrentScore > 21 || DealerCurrentScore < CurrentScore)
            {
                Debug.Log("the dealer has been beat and you win");
                for (int i = 0; i < 5; i++)
                {
                    Cardsinhand[i] = "N/A";
                    DealerCardsinhand[i] = "N/A";
                    CurrentScore = 0;
                    DealerCurrentScore = 0;
                    AceReduced = false;
                    Standing = false;
                }
                M_Moneymanager.bet = M_Moneymanager.bet * 2;
                M_Moneymanager.playersChips = M_Moneymanager.bet;
                M_Moneymanager.Start();
            }
            else if (DealerCurrentScore == CurrentScore)
            {
                Debug.Log("draw you get your bet back");
                for (int i = 0; i < 5; i++)
                {
                    Cardsinhand[i] = "N/A";
                    DealerCardsinhand[i] = "N/A";
                    CurrentScore = 0;
                    DealerCurrentScore = 0;
                    AceReduced = false;
                    Standing = false;
                }
                M_Moneymanager.Start();
            }
                

            else
            {
                Debug.Log("you lose");
                for (int i = 0; i < 5; i++)
                {
                    Cardsinhand[i] = "N/A";
                    DealerCardsinhand[i] = "N/A";
                    CurrentScore = 0;
                    DealerCurrentScore = 0;
                    AceReduced = false;
                    Standing = false;
                }
                M_Moneymanager.playersChips -= M_Moneymanager.bet;
                M_Moneymanager.Start();
            }
        }
    }
}