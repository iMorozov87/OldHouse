using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player), typeof(PlayerAttacker), typeof(PlayerMover))]
public class PlayerEnhancer : MonoBehaviour
{
    //Да, тут торопился, время уже поджимало. Надо было сделать коллекцией, и ее основе спавнить View
    //Рома, если смотришь - извини.

    [SerializeField] private PlayerPropertiesInt _health;
    [SerializeField] private PlayerPropertiesInt _demage ;   

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
        ValueSetted?.Invoke(_health, _demage);
    }

    public void SetValue(PlayerPropertiesInt properties)
    {
        if (properties == _health)
            _player.IncreaseHealth();
        else
            _playerAttacker.IncreaseDemage();
        properties.SetNextValue();
        ValueSetted?.Invoke(_health, _demage);
    }
}
