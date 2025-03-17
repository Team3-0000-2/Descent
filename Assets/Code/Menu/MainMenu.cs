using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //change the scene number
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
