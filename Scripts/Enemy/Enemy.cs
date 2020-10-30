using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _reward = 1;
    [SerializeField] private int _scorePerClick = 1;
    [SerializeField] private VisualEffector _visualEffector;

    private int _currentHealth;
    private uint _level = 1;

    public int Health => _health;
    public int Reward => _reward;
    public int ScorePerClick => _scorePerClick;

    public event UnityAction Died;
    public event UnityAction<uint> LevelSetted;

    private void Awake()
    {
        _currentHealth = _health;
    }

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(Vector3 mousePosition)
    {
        _currentHealth--;
        _visualEffector.PlayDamageEffects(mousePosition);
        {
            if (_currentHealth <= 0)
            {
                Died?.Invoke();
                Die();
            }
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void SetLevel(Spawner levelSource)
    {       
        _level = levelSource.EnemyLevel;
        LevelSetted?.Invoke(_level);
    }

    public void SetEnemy(EnemyParametersSelector enemyParameters)
    {
        _health = enemyParameters.Health;
        _currentHealth = _health;
        _reward = enemyParameters.Reward;
        _scorePerClick = enemyParameters.ScorePerClick;
    }
}
