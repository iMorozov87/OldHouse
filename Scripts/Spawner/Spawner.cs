using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private EnemiesPool _enemiesPool;
    [SerializeField] private ParticleSystem _emergenceEffect;

    private Transform[] _spawnPoints;

    private float _spawnDelay = 3F;
    private float _currentTime = 0;
    private int _numberOfSpawns = 0;
    private uint _enemyLevel = 1;

    public uint EnemyLevel => _enemyLevel;
    public float SpawnDelay => _spawnDelay;

    public event UnityAction<int> Spawned;

    private void Awake()
    {
        _spawnPoints = CreateSpawnPoints();
        _enemiesPool.Initialize(_enemyTemplate.gameObject);
    }

    private Transform[] CreateSpawnPoints()
    {
        Transform[] spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
        return spawnPoints;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        {
            if (_currentTime >= _spawnDelay)
            {
                _numberOfSpawns++;
                Spawned?.Invoke(_numberOfSpawns);
                int numberPoint = UnityEngine.Random.Range(0, _spawnPoints.Length);
                StartCoroutine(EmergenceEnemy(numberPoint));
                _currentTime = 0;
            }
        }
    }

    public void SetEnemyLevel(DifficultyIncreaser sourceEnemyLevel)
    {
        _enemyLevel = sourceEnemyLevel.CurrentLevelEnemy;
    }

    public void SetSpawnDelay(DifficultyIncreaser sourceDelay)
    {
        _spawnDelay = sourceDelay.CurrentSpawnDelay;
    }

    private IEnumerator EmergenceEnemy(int numberPoint)
    {
        float secondsDalay = 0.7F;
        ParticleSystem emergenceEffect = Instantiate(_emergenceEffect, _spawnPoints[numberPoint].position, Quaternion.identity);

        yield return new WaitForSeconds(secondsDalay);
        Destroy(emergenceEffect.gameObject);
        SetEnemy(numberPoint);
    }

    private void SetEnemy(int numberPoint)
    {
        GameObject enemy = _enemiesPool.GetObject();
        enemy.SetActive(true);
        enemy.GetComponent<EnemyMover>().SetPositions(_spawnPoints[numberPoint].position);
        enemy.GetComponent<Enemy>().SetLevel(this);
    }
}
