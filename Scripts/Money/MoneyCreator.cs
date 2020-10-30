using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class MoneyCreator : MonoBehaviour
{
    [SerializeField] private Money _moneyTemplate;

    private Enemy _moneySource;
    private Money _money;    

    private void Awake()
    {
        _moneySource = GetComponent<Enemy>(); 
    }
    private void OnEnable()
    {
        _moneySource.Died += OnMoneySourceDied;
    }

    private void OnDisable()
    {
        _moneySource.Died -= OnMoneySourceDied;
    }

    private void OnMoneySourceDied()
    {
        _money = CreateMoney();
        _money.SetMoney(_moneySource);
    }

    private Money CreateMoney()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        Money money = Instantiate(_moneyTemplate, position, Quaternion.identity);
        return money;
    }
}
