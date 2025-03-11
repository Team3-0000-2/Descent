using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    public void Update()
    {
        this.transform.Translate(this.transform.forward * _speed * Time.deltaTime);
        
    }
}
