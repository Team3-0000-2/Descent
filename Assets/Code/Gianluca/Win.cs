using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private StartTimer _st;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _st._reactorIsBroken)
        {
            SceneManager.LoadScene("Win"); //Carica scena di vittoria
        }
    }
}
