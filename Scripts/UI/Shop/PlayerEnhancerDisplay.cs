using System;
using UnityEngine;

public class PlayerEnhancerDisplay : MonoBehaviour
{
    [SerializeField] private PropertiesView _healthBuyView;
    [SerializeField] private PropertiesView _demageBuyView;
    [SerializeField] private PlayerEnhancer _playerEnhancer;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _playerEnhancer.ValueSetted += OnValueSetted;
        _healthBuyView.BuyTried += OnBuyTried;
        _demageBuyView.BuyTried += OnBuyTried;
    } 

    private void OnDisable()
    {
        _playerEnhancer.ValueSetted -= OnValueSetted;
        _healthBuyView.BuyTried -= OnBuyTried;
        _demageBuyView.BuyTried -= OnBuyTried;
    }

    private void OnValueSetted(PlayerPropertiesInt health, PlayerPropertiesInt demage)
    {
        _healthBuyView.Init(health);
        _demageBuyView.Init(demage);
    }

    private void OnBuyTried(PlayerPropertiesInt properties)
    {
        if (_player.TryPickMoney(properties.NextPrice))
            _playerEnhancer.SetValue(properties); 

    }
}
