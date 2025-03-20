using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public void GoToMainMenu()
    { 
        SceneManager.LoadScene(0); //change the scene number
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
