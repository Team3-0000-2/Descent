using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] private float _speed;
    [SerializeField] private int damage;
    public void Update()
    {

    /*
        Ho commentato questa parte di codice per dare un effetto più naturale al proiettile direttmente allo spawn
     */

      //  this.transform.Translate(this.transform.forward * _speed * Time.deltaTime);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")|| collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().AddDamage(damage);
        }
        Destroy(this.gameObject);
    }




}
