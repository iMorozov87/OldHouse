using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Money : MonoBehaviour
{
    [SerializeField, Range (1,100)] private int _numberCounts = 1;

    private Rigidbody2D _rigidbody2D;

    public int NumberCounts => _numberCounts;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        TossMoney();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.AddMoney(this);
            Destroy(gameObject);
        }
    }

    public void SetMoney(Enemy moneySource)
    {
        _numberCounts = moneySource.Reward;
    }

    private void TossMoney()
    {
        float valueRange = 0.7F;
        float directionX = Random.Range(-valueRange, valueRange);
        float directionY = 1;
        float directionZ = 0;        
      
        Vector3 direction = new Vector3(directionX, directionY, directionZ);
        _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }
}
