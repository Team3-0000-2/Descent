using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private byte type;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private StartTimer _st;

    public Action<int> OnHealthChange;

    public void AddDamage(int damage)
    {
        switch (type)
        {
            case 0: //se player
                currentHealth -= damage / 2;
                if (currentHealth <= 0)
                {
                    Destroy(this.gameObject);
                    //gameOverScreen();
                    SceneManager.LoadScene(2);
                }
                break;
            case 1: // se nemico
                if (currentHealth > 0)
                {
                    currentHealth -= damage;
                }
                else
                {
                    if (gameObject.CompareTag("Reactor"))
                    {
                        _st._reactorIsBroken = true;
                    }
                    Destroy(this.gameObject);
                }
                break;
            default:
                break;
        }

        OnHealthChange(damage);

        
    }

    /*
    public void gameOverScreen()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        isDead = true;
    }


    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); //change the scene number
        isDead = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    */
}