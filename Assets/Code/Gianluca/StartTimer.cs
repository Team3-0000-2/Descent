using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] public bool _reactorIsBroken;

    private void Update()
    {
        if (_reactorIsBroken)
        {
            if (_time <= 0)
            {
                Debug.Log("Sei morto scemo");
            }
            else
            {
                _time -= Time.deltaTime;
            }
            Debug.Log("Timer: " + _time);
        }
    }

}
