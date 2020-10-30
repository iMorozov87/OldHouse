using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover), typeof(PlayerAttacker))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CursorTracker _cursorTracker;
    
    private PlayerMover _playerMover;
    private PlayerAttacker _playerAttacker;
    private Vector3 _screenMousePosition => _cursorTracker.ScreenMousePosition;
    private Vector3 _worldMousePosition => _cursorTracker.WorldMousePosition;

    private void Awake()
    {   
        _playerMover = GetComponent<PlayerMover>();
        _playerAttacker = GetComponent<PlayerAttacker>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _playerMover.SetTarget(_worldMousePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _playerAttacker.TryAttack(_screenMousePosition, _worldMousePosition);            
        }
    }
}
