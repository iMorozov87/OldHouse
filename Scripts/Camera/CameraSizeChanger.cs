using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraSizeChanger : MonoBehaviour
{
    [SerializeField] private float _targetSize;
    [SerializeField] private float _duration;
    [SerializeField] private Player _player;

    private Camera _camera;
    private float _starSize;

    private void Awake()
    {
        _camera = Camera.main;
        _starSize = _camera.orthographicSize;
    }

    private void OnEnable()
    {
        _player.Died += OnChanSize;
    }

    private void OnDisable()
    {
        _player.Died -= OnChanSize;
    }

    private void  OnChanSize()
    {
        StartCoroutine(ChangeSize(_camera.orthographicSize, _starSize, _duration));
    }

    private void Start()
    {
        StartCoroutine(ChangeSize(_camera.orthographicSize, _targetSize, _duration));
    }

    
    private IEnumerator ChangeSize(float startSize, float targetSize, float duration)
    {
        float elapsedTime = 0;
        float currentSize ;
        while (elapsedTime < duration)
        {
            currentSize = Mathf.Lerp(startSize, targetSize, elapsedTime/duration);
            _camera.orthographicSize = currentSize;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _camera.orthographicSize = targetSize;
    }
}
