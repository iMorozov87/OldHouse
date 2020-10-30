using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _screenMousePosition;    
    private Vector3 _worldMousePosition;

    public Vector3 ScreenMousePosition => _screenMousePosition;
    public Vector3 WorldMousePosition => _worldMousePosition;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        _screenMousePosition = Input.mousePosition;
        _worldMousePosition = _camera.ScreenToWorldPoint(new Vector3(_screenMousePosition.x, _screenMousePosition.y, 10));
        transform.position = _worldMousePosition;        
    }
}
