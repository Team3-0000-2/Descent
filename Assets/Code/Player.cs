using UnityEngine;

public class Player : MonoBehaviour
{

    private HealthManager healthManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        healthManager.OnHealthChange += OnHealthChange ;

    }

    public void OnHealthChange(int health)
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
