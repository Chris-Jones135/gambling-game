using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    private InputAction PauseAction;

    private void Start()
    {
        PauseAction = InputSystem.actions.FindAction("Pause");
    }
    // closes the pause menu when the "resume" button is clicked
    public void CloseOnClick()
    {
        Menu.SetActive(false);
    }

    // opens the pause menu when the player presses esc (the pause bind)
    public void Update()
    {
        if (PauseAction.IsPressed())
        {
            Menu.SetActive(true);
        }
    }
}
