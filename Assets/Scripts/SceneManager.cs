using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //enter the name of the scene to load on the button clicked
    public string sceneToLoad;


    //Loads the typed out scene (enter scene in GAMEMANAGER gameobject in the start menu screen)
    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    // Causes the game to close when the button is clicked
    public void QuitOnClick()
    {
        // THIS IS ONLY FOR MAKING SURE THE CODE WORKS. REMOVE BEFORE COMPILING.
        UnityEditor.EditorApplication.isPlaying = false;
        //closes the game lol
        Application.Quit();
    }
}