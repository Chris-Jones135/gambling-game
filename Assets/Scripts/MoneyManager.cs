using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    
    [SerializeField] private int maxChips;
    public int remainingChips;
    public int playersChips;
    public int bet;
    public bool Inven;
    public TMPro.TextMeshProUGUI betAmount;
    public GameObject Call;
    public GameObject Stand;
    public GameObject Standby_Call;
    public GameObject Standby_Stand;
    public GameObject Bet_Panel;
    public GameObject Inven_Panel;
    public Card_script m_Card_script;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Call.SetActive(false);
        Stand.SetActive(false); 
        Standby_Call.SetActive(true);
        Standby_Stand.SetActive(true);
        Bet_Panel.SetActive(true);
        Inven_Panel.SetActive(false);
    }

    public void Bet()
    {
        if (bet == 0)
        {
            Debug.Log("no");
        }
        else
        {
            Call.SetActive(true);
            Stand.SetActive(true);
            Standby_Call.SetActive(false);
            Standby_Stand.SetActive(false);
            Bet_Panel.SetActive(false);
            Inven_Panel.SetActive(true);
            Inven = true;
            m_Card_script.start();
        }

            
    }


    public void BetUp(int scoreToAdd)
    {
        bet += scoreToAdd;
        if (bet > playersChips)
        {
            bet = playersChips;
        }
    }

    public void BetDown(int scoreToTake)
    {
        bet -= scoreToTake;
        if (bet < 0)
        {
            bet = 0;
        }

    }

    void Update()
    {
        betAmount.text = "" + bet;
        remainingChips = maxChips - playersChips;
    }
}
