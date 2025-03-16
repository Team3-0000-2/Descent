using UnityEngine;
using System.Collections;


public class IA : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _self;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Vector3 _velocity = Vector3.zero;
    [SerializeField] private byte _waypointsIndex;
    [SerializeField] private float _distanceToTarget;
    [SerializeField] private bool _targetReached;
    [SerializeField] private float _timeToTarget;
    [SerializeField] private Status _status;


    enum Status : byte
    {
        Patroll = 0,
        Chasing = 1
    }

    private void Awake()
    {
        _self = this.transform;
        _target = _waypoints[0];
        _status = Status.Patroll;
    }

    private void Update()
    {
        _self.LookAt(_target);
        _distanceToTarget = Vector3.Distance(_self.position, _target.position);
        if (_distanceToTarget <= 0.5f)
        {
            if(_status == Status.Patroll)
                Patroll();
            _targetReached = true;
            if (_status == Status.Chasing)
                Chase();
        }
        else
        {
            _targetReached = false;
        }
        if (!_targetReached)
        {
            _self.position = Vector3.MoveTowards(_self.position, _target.position, _timeToTarget*Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.transform;
            _status = Status.Chasing;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _status = Status.Patroll;
    }
    private void Patroll()
    {
        if (_waypointsIndex < _waypoints.Length - 1)
            _waypointsIndex++;
        else
            _waypointsIndex = 0;
        _target = _waypoints[_waypointsIndex];
    }

    private void Chase()
    {

        Debug.Log("Chasing!");
    }

}
