using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Vector3 _target;

    public float Speed => _speed;

    private void Awake()
    {
        _target = transform.position;        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
        ChooseTurn(target.x);
    }

    private void ChooseTurn(float targetHorizontal)
    {
        float scaleX;
        if (targetHorizontal < transform.position.x)
            scaleX = -1;
        else
            scaleX = 1;
        Flip(scaleX);
    }

    private void Flip(float scaleX)
    {
        transform.localScale = new Vector2(scaleX, transform.localScale.y);
    }    
}
