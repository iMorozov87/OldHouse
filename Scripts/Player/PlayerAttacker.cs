using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private int _demage = 1;

    private Camera _camera;

    public int Demage => _demage;

    public event UnityAction<int> Attaked;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void TryAttack(Vector3 screenMousePosition, Vector3 worldMousePosition)
    {
        Ray clickRay = _camera.ScreenPointToRay(screenMousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickRay.origin, clickRay.direction);

        if (hit.collider != null && hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(worldMousePosition);
            Attaked?.Invoke(enemy.ScorePerClick);
        }
    }  
}
