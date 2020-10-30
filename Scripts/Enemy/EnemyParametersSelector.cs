using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Enemy), typeof(EnemyMover))]
public class EnemyParametersSelector : MonoBehaviour
{
    [SerializeField] private EnemyParameterInt _health;
    [SerializeField] private EnemyParameterInt _reward;
    [SerializeField] private EnemyParameterInt _scorePerClick;
    [SerializeField] private EnemyParameterFloat _startSpeed;
    [SerializeField] private EnemyParameterFloat _radiusMovement;

    private Enemy _enemy;
    private EnemyMover _enemyMover;
    private uint _currentLevel;

    public int Health => _health.Value;
    public int Reward => _reward.Value;
    public int ScorePerClick => _scorePerClick.Value;
    public float StartSpeed => _startSpeed.Value;
    public float RadiusMovement => _radiusMovement.Value;
    
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyMover = GetComponent<EnemyMover>();
        SetAllStartParameters();
    }

    private void OnEnable()
    {
        _enemy.LevelSetted += OnLevelSetted;
    }

    private void OnDisable()
    {
        _enemy.LevelSetted -= OnLevelSetted;
    }

    private void OnLevelSetted(uint level)
    {        
        _currentLevel = level;
        SetAllParameters();
        _enemy.SetEnemy(this);
        _enemyMover.SetEnemyMover(this);
    }

    private void SetAllStartParameters()
    {       
        _health.Value = _enemy.Health;
        _reward.Value = _enemy.Reward;
        _scorePerClick.Value = _enemy.ScorePerClick;       
        _startSpeed.Value = _enemyMover.StartSpeed;
        _radiusMovement.Value = _enemyMover.RadiusMovement;
    }

    private void SetAllParameters()
    {        
        _health.Value = SetValueParameter(_health);
        _reward.Value = SetValueParameter(_reward);      
        _scorePerClick.Value = SetValueParameter(_scorePerClick);     
        _startSpeed.Value = SetValueParameter(_startSpeed);
        _radiusMovement.Value = SetValueParameter(_radiusMovement);
    }

    private int  SetValueParameter(EnemyParameterInt parameter)
    {
        uint startLevel = 1;
        if (parameter.Value < parameter.MaxValue && _currentLevel > startLevel)
        {
            int valueDelta = (int)(_currentLevel / parameter.MaxLevelToInceas) * parameter.ValueStep;
            parameter.Value += valueDelta;
        }
        return parameter.Value;
    }

    private float SetValueParameter(EnemyParameterFloat parameter)
    {
        if (parameter.Value < parameter.MaxValue)
        {
            float valueDelta = (int)(_currentLevel / parameter.MaxLevelToInceas) * parameter.ValueStep;
            parameter.Value += valueDelta;
        }    
        return parameter.Value;
    }

    [System.Serializable]
    public class EnemyParameterInt
    {
        public int Value;
        public int MaxValue;
        public int ValueStep;
        public uint MaxLevelToInceas;
    }

    [System.Serializable]
    public class EnemyParameterFloat 
    {
        public float Value;
        public float MaxValue;
        public float ValueStep;
        public uint MaxLevelToInceas;
    }
}
