using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover), typeof(PlayerAttacker))] 
public class Player : MonoBehaviour
{
    [SerializeField] private VisualEffector _visualEffector;
    [SerializeField]private int _health = 5;

    private PlayerMover _playerMover;
    private PlayerAttacker _playerAttacker;
    private int _money;
    private int _score;

    public int Health => _health;
    public int Money => _money;
    public int Score => _score;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> HealhChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerAttacker = GetComponent<PlayerAttacker>();
    }

    private void OnEnable()
    {
        _playerAttacker.Attaked += AddScore;
    }

    private void OnDisable()
    {
        _playerAttacker.Attaked -= AddScore;
    }

    public bool TryPickMoney(int price)
    {
        if(price <=_money)
        {
            _money -= price;
            return true;
        }
        return false;
    }

    private void Start()
    {
        HealhChanged?.Invoke(_health);
        ScoreChanged?.Invoke(_score);
        MoneyChanged?.Invoke(_money); 
    }

    private void AddScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }

    public void TakeDemage()
    {
        _health--;
        HealhChanged?.Invoke(_health);
        _visualEffector.PlayDamageEffects();
        if (_health <= 0)
        {            
            Died?.Invoke();
            Die();
        }
    }
    
    public void AddMoney(Money money)
    {
        _money += money.NumberCounts;
        MoneyChanged?.Invoke(_money);
    }

    public void SetSaveData(DataSaver dataSaver)
    {
        _money= dataSaver.Money;
        _score = dataSaver.Score;
    }

    private void Die()
    {
        _visualEffector.PlayDiedEffects();
        _playerMover.enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;
    }
}