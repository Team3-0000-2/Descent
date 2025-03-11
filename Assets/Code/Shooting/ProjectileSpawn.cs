using UnityEngine;


public class ProjectileSpawn : MonoBehaviour
{

    [SerializeField] private Transform[] projectileSpawn;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int contatore;
    public void Shoot()
    {
        
        Instantiate(projectile, projectileSpawn[contatore].position, projectileSpawn[contatore].rotation);
        if (contatore == 1)
        contatore = 0;
        else
            contatore = 1;
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
}
