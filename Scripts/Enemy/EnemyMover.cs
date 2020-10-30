using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 2;
    [SerializeField] private float _coefficientMagnificationSpeed = 2.0F;
    [SerializeField] private float _radiusMovement = 3.0F;
    [SerializeField] private FieldOfView _fieldOfView;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Player _player;
    private float _speed;
    private bool _isPatol = true;

    public float StartSpeed => _startSpeed;
    public float RadiusMovement => _radiusMovement;

    private void Awake()
    {
        _speed = _startSpeed; 
    }

    private void OnEnable()
    {
        _fieldOfView.PlayerDiscovered += OnPlayerDiscored;
        _fieldOfView.PlayerGone += OnPlayerGone;
    }

    private void OnDisable()
    {
        _fieldOfView.PlayerDiscovered -= OnPlayerDiscored;
        _fieldOfView.PlayerGone -= OnPlayerGone;
    }

    public void SetPositions(Vector3 position)
    {        
        _startPosition = position;
        _targetPosition = SetNewTargetPoint();
        transform.position = position;
    } 

    private void OnPlayerDiscored(Player player)
    {
        _player = player;
        _isPatol = false;
        _speed = _startSpeed *_coefficientMagnificationSpeed;
    }

    private void OnPlayerGone(Player player)
    {      
        _targetPosition = SetNewTargetPoint();
        _isPatol = true;
        _speed = _startSpeed;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (_isPatol == true && transform.position == _targetPosition)
            _targetPosition = SetNewTargetPoint();
        if (_isPatol == false)
            _targetPosition = new Vector3 (_player.transform.position.x, _player.transform.position.y, _startPosition.z);
    }

    public void SetEnemyMover(EnemyParametersSelector enemyParameters)
    {
        _startSpeed = enemyParameters.StartSpeed;
        _speed = _startSpeed;
        _radiusMovement = enemyParameters.RadiusMovement;
    }

    private Vector3 SetNewTargetPoint()
    {
        Vector3 newPosition = _startPosition + (Vector3)(UnityEngine.Random.insideUnitCircle * _radiusMovement);
        return newPosition;
    }
}
