using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class DifficultyIncreaser : MonoBehaviour
{
    [SerializeField] private int _maxNumberSpawnToIncease = 10;

    private Spawner _spawner;
    private float _startSpawnDelay;
    private float _currentSpawnDelay;
    private uint _currentLevelEnemy = 1;

    public float  CurrentSpawnDelay => _currentSpawnDelay;
    public uint CurrentLevelEnemy => _currentLevelEnemy;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void Start()
    {
        _startSpawnDelay = _spawner.SpawnDelay;
        _currentSpawnDelay = _startSpawnDelay;
    }

    private void OnEnable()
    {
        _spawner.Spawned += TryIncreaseDifficulty;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= TryIncreaseDifficulty;
    }

    private void TryIncreaseDifficulty(int numberOfSpawns)
    {        
        bool isIncrease = numberOfSpawns % _maxNumberSpawnToIncease == 0;
        if (isIncrease)
            IncreaseDifficulty();
    }

    private void IncreaseDifficulty()
    {
        _currentLevelEnemy++;
        _currentSpawnDelay = GetNewSpawnDelay(_currentSpawnDelay);
        _spawner.SetSpawnDelay(this);
        _spawner.SetEnemyLevel(this);
    }
    
    private float GetNewSpawnDelay(float currentSpawnDelay)
    {
        float deltaSpawnDelay = 0.2F;
        currentSpawnDelay -= deltaSpawnDelay;
        if (currentSpawnDelay <= 1.5F)
            currentSpawnDelay = _startSpawnDelay;
        return currentSpawnDelay;
    }
}
