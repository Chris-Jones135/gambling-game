using UnityEngine;

public class Items_script : MonoBehaviour
{
    public GameObject Card_Panel;
    public GameObject Card_1;
    public GameObject Card_2;

    public Card_script m_Card_Script;
    public Inven_script m_Inven_Script;
    int Drunk = 0;
    bool YSAdded = false;

    void Start()
    {
        Card_Panel.SetActive(false);
    }

    //one card value increased by 1
    public void Marker()
    {
        m_Card_Script.CurrentScore += 1;
        Debug.Log("you used the marker on a card in you hand");
        Debug.Log(m_Card_Script.CurrentScore);
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
        int Miss = Random.Range(0, 2);
        if (Miss == 0)
        {
            //take card one from dealer
        }
        else if (Miss == 1)
        {
            //take card two from dealer
        }
        else if (Miss == 2)
        {
            //miss
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
        m_Card_Script.Cardsinhand[0] = "N/A";

    }
}
