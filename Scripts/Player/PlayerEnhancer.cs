using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player), typeof(PlayerAttacker), typeof(PlayerMover))]
public class PlayerEnhancer : MonoBehaviour
{
    [SerializeField] private PlayerPropertiesInt _health;
    [SerializeField] private PlayerPropertiesInt _demage ;
    [SerializeField] private PlayerPropertiesFloat _speed;

    private Player _player;
    private PlayerMover _playerMover;
    private PlayerAttacker _playerAttacker;

    public event UnityAction<PlayerPropertiesInt, PlayerPropertiesInt> ValueSetted;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerAttacker = GetComponent<PlayerAttacker>();     
    }

    private void Start()
    {
        SetAllValue();
    }

    private void SetAllValue()
    {
        _health.SetNextValue();
        _demage.SetNextValue();
        ValueSetted?.Invoke(_health, _demage);
    }

    public void SetValue(PlayerPropertiesInt properties)
    {
        properties.SetNextValue();
    }
}
