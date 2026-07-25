using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public Card_script m_Card_script;

    //sets the starting inventory size to 5 slots
    [SerializeField] private string[] Inven = { "Marker", "N/A", "N/A", "N/A", "N/A" };
    
    //gets the panel and buttons for the inventory ui
    public GameObject Inven_Panel;
    public GameObject Item_1;
    public GameObject Item_2;
    public GameObject Item_3;
    public GameObject Item_4;
    public GameObject Item_5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    //item buttons checking when pressed
    public void UseItem1()
    {
        if (Inven[0] == "N/A")
        {
            Debug.Log("BUY SOMETHING FAG");
        }
        else if (Inven[0] == "Marker")
        {
            m_Card_script.CurrentScore += 1;
            Debug.Log("you used the marker on a card in you hand");
            Debug.Log(m_Card_script.CurrentScore);
            Inven[0] = "N/A";
        }
    }

    public void UseItem2()
    {
        if (Inven[1] == "N/A")
        {
            Debug.Log("BUY SOMETHING FAG");
        }
        else if (Inven[1] == "Marker")
        {
            m_Card_script.CurrentScore += 1;
            Debug.Log("you used the marker on a card in you hand");
            Debug.Log(m_Card_script.CurrentScore);
            Inven[1] = "N/A";
        }
    }

    public void UseItem3()
    {
        if (Inven[2] == "N/A")
        {
            Debug.Log("BUY SOMETHING FAG");
        }
        else if (Inven[2] == "Marker")
        {
            m_Card_script.CurrentScore += 1;
            Debug.Log("you used the marker on a card in you hand");
            Debug.Log(m_Card_script.CurrentScore);
            Inven[2] = "N/A";
        }
    }

    public void UseItem4()
    {
        if (Inven[3] == "N/A")
        {
            Debug.Log("BUY SOMETHING FAG");
        }
        else if (Inven[3] == "Marker")
        {
            m_Card_script.CurrentScore += 1;
            Debug.Log("you used the marker on a card in you hand");
            Debug.Log(m_Card_script.CurrentScore);
            Inven[3] = "N/A";
        }
    }

    public void UseItem5()
    {
        if (Inven[4] == "N/A")
        {
            Debug.Log("BUY SOMETHING FAG");
        }
        else if (Inven[4] == "Marker")
        {
            m_Card_script.CurrentScore += 1;
            Debug.Log("you used the marker on a card in you hand");
            Debug.Log(m_Card_script.CurrentScore);
            Inven[4] = "N/A";
        }
    }

    //string ItemAdder(string[] Item)
    //{

    //}

    // Update is called once per frame

    void Update()
    {

    }
}
