using UnityEngine;
using UnityEngine.UI;

public class Inven_script : MonoBehaviour
{
    public Items_script m_Items_Scipt;

    //sets the starting inventory size to 5 slots
    [SerializeField] private int[] Inven = { 999, 999, 999, 999, 4 };
    
    //gets the panel and buttons for the inventory ui
    public GameObject Inven_Panel;
    public GameObject Item_1;
    public GameObject Item_2;
    public GameObject Item_3;
    public GameObject Item_4;
    public GameObject Item_5;
    public int Item = 99999;

    void Update()
    {
        //switch case for using items
        switch (Item)
        {
            case 0:
                m_Items_Scipt.Marker();
                break;
            case 1:
                m_Items_Scipt.CheepPlasticCrown();
                break;
            case 2:
                m_Items_Scipt.beer();
                break;
            case 3:
                m_Items_Scipt.YouStupid();
                break;
            case 4:
                m_Items_Scipt.stickyhand();
                break;
            default:
                break;
        }
        Item = 99999;
    }

    //item buttons checking when pressed
    public void UseItem1()
    {
        if (Inven[0] == 999)
        {
            Debug.Log("buy something fag");
        }
        else
        {
            Item = Inven[0];
            Inven[0] = 999;
        }
    }

    public void UseItem2()
    {
        if (Inven[1] == 999)
        {
            Debug.Log("buy something fag");
        }
        else
        {
            Item = Inven[1];
            Inven[1] = 999;
        }
    }

    public void UseItem3()
    {
        if (Inven[2] == 999)
        {
            Debug.Log("buy something fag");
        }
        else
        {
            Item = Inven[2];
            Inven[2] = 999;
        }
    }

    public void UseItem4()
    {
        if (Inven[3] == 999)
        {
            Debug.Log("buy something fag");
        }
        else
        {
            Item = Inven[3];
            Inven[3] = 999;
        }
    }

    public void UseItem5()
    {
        if (Inven[4] == 999)
        {
            Debug.Log("buy something fag");
        }
        else
        {
            Item = Inven[4];
            Inven[4] = 999;
        }
    }
}
