using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int deltaHeart = value - _hearts.Count;
            for (int i = 0; i < deltaHeart; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value & _hearts.Count != 0)
        {
            int deltaHeart = _hearts.Count - value;
            for (int i = 0; i < deltaHeart; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
                if (_hearts.Count == 0)
                    return;
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        Destroy(heart.gameObject);
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart);        
    }
}
