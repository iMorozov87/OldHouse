using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private GameObject _template;
    private List<GameObject> _enemiesPool = new List<GameObject>();

    public void Initialize(GameObject prefabs)
    {
        _template = prefabs;
        for (int i = 0; i < _capacity; i++)
        {
            CreateEnemy();
        }
    }

    public GameObject GetObject()
    {
        if (TryGetObject(out GameObject enemy) == false)
            enemy = CreateEnemy();
        return enemy;
    }

    private bool TryGetObject(out GameObject result)
    {
        result = null;
        foreach (var enemy in _enemiesPool)
        {
            if (enemy.activeSelf == false)
            {
                result = enemy;
                return true;
            }
        }   
        return  false;
    }

    private GameObject CreateEnemy()
    {
        GameObject spawned = Instantiate(_template, _container.transform);
        spawned.SetActive(false);
        _enemiesPool.Add(spawned);
        return spawned;
    }
}
