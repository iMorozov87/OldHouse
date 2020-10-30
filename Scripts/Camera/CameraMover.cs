using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CursorTracker _cursorTracker;
    [SerializeField] private BoundariesCamera _boundariesCamera;
    [SerializeField] private float _speed = 4;

    private Camera _camera;
    private Vector3 _mousePosition => _cursorTracker.ScreenMousePosition;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _targetPosition = transform.position;        
    }

    private void LateUpdate()
    {
        if (RequiredSetNewTarget())
            _targetPosition = _camera.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, 0));
        else
            _targetPosition = transform.position;
        _targetPosition = _boundariesCamera.ClampMovement(_targetPosition);
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private bool RequiredSetNewTarget()
    {
        int offSet = 10;
        bool isRequired = false;
        if (_mousePosition.x <= offSet || _mousePosition.x >= (_camera.pixelWidth - offSet) ||
            _mousePosition.y <= offSet || _mousePosition.y >= (_camera.pixelHeight - offSet))
            isRequired = true;
        return isRequired;
    }
}
