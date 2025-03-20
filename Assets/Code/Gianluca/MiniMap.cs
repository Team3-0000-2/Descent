using UnityEngine;

public class MiniMap : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _container;
    [SerializeField] private float _angle;
    [SerializeField] private bool _canRotate;
    [SerializeField] private Movement _Movement;
    [SerializeField] private Animator _ac;



    void Update()
    {
        this.transform.LookAt(_target);
        if (Input.GetKey(KeyCode.Tab))
        {
            _canRotate = !_canRotate;
        }
        if (_canRotate)
        {
            _Movement._canMove = false;
            _ac.SetBool("ToMiniMap", true);
            float _moveForward = (Input.GetKey(KeyCode.Q) ? 1 : 0) - (Input.GetKey(KeyCode.E) ? 1 : 0);
            this.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), _moveForward));
           // Debug.Log("H: " + Input.GetAxis("Horizontal"));
            //Debug.Log("V: " + Input.GetAxis("Vertical"));
        }
        else
        {
            _Movement._canMove = true;
            _ac.SetBool("ToMiniMap", false);
        }
    }
}
