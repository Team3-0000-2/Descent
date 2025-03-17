using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class IA : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private CharacterController _cc;
    [SerializeField] private Transform _self;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Vector3 _velocity = Vector3.zero;
    [SerializeField] private Vector3 _targetDirection;
    [SerializeField] private Vector3 _directionToTake;
    [SerializeField] private byte _waypointsIndex;
    [SerializeField] private float _distanceToTarget;
    [SerializeField] private bool _targetReached;
    [SerializeField] private bool _canShoot;
    [SerializeField] private float _speed;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _wallDetectionDistance;
    [SerializeField] private Status _status;
    [SerializeField] private RaycastHit _hit;
    [SerializeField] private ProjectileSpawn _shoot;


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
        _cc = GetComponent<CharacterController>();
        _shoot = GetComponent<ProjectileSpawn>();
        Patroll();
    }

    private void Update()
    {
        _self.LookAt(_target);
        //Change in something better
        _distanceToTarget = Vector3.Distance(_self.position, _target.position);
        _targetDirection = Vector3.Normalize(_target.position - _self.position);
        //Debug.Log("Direzione: " + _targetDirection);
        if (_distanceToTarget > 0.5f)
        {
            if (Physics.Raycast(_self.position, _targetDirection, out _hit, _wallDetectionDistance))
            {
                _directionToTake = Vector3.Normalize(_self.position - _hit.transform.position);
                _cc.Move(_directionToTake * _speed * Time.deltaTime);

            }
            else
            {
                _cc.Move(_targetDirection * _speed * Time.deltaTime);
            }
        }
        if (_distanceToTarget <= 0.5f)
        {
            if(_status == Status.Patroll && !_target.CompareTag("Player"))
            {

            _targetReached = true;
                Patroll();
            }
        }
        else
        {
            _targetReached = false;
        }
        if (!_targetReached)
        {
           // _self.position = Vector3.MoveTowards(_self.position, _target.position, _timeToTarget*Time.deltaTime);
        }
        if (_status == Status.Chasing)
            Chase();
    }

    private void OnTriggerStay(Collider other)
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
        _target = other.transform;
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
        if (_canShoot)
            StartCoroutine(Shoot());
    }


    IEnumerator Shoot()
    {
        _canShoot = false;
        _shoot.Shoot();
        yield return new WaitForSeconds(1/_rateOfFire);
        _canShoot = true;
    }
}
