using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private byte type;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public Action<int> OnHealthChange;

    public void AddDamage(int damage)
    {
        switch (type)
        {
            case 0: //se player
                currentHealth -= damage/2;
                break;
            case 1: // se nemico
                currentHealth -= damage;
                break;
            default:
                break;



        }

        OnHealthChange(damage);

        //if (currentHealth <= 0)
        //{
            //Destroy(this.gameObject);
        //}
    }
} 