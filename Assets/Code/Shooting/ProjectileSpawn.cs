using UnityEngine;


public class ProjectileSpawn : MonoBehaviour
{

    [SerializeField] private Transform[] projectileSpawn;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int contatore;
    [SerializeField] private float bulletForce;
    public void Shoot()
    {
        /*
        Ho aggiunto questa parte di codice che gestisce spinta e spawn della pallina facendo si che ora si sposti secondo la direzione della canna
        */
        GameObject bullet = Instantiate(projectile, projectileSpawn[contatore].position, projectileSpawn[contatore].rotation);
        Rigidbody _rb = bullet.GetComponent<Rigidbody>();
        _rb.AddForce(projectileSpawn[contatore].forward * bulletForce, ForceMode.Impulse);
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
