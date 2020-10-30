using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesCamera : MonoBehaviour
{
    [SerializeField] private Transform _leftUpperBorderCamera;
    [SerializeField] private Transform _rightLowerBorderCamera;

    private float _minHeightMovement;
    private float _maxHeightMovement;
    private float _minWidthMovement;
    private float _maxWidthMovement;

    private void Awake()
    {
        _minHeightMovement = _rightLowerBorderCamera.position.y;
        _maxHeightMovement = _leftUpperBorderCamera.position.y;
        _minWidthMovement = _leftUpperBorderCamera.position.x;
        _maxWidthMovement = _rightLowerBorderCamera.position.x;
    }

    public Vector3 ClampMovement(Vector3 target)
    {
        target.x = Mathf.Clamp(target.x, _minWidthMovement, _maxWidthMovement);
        target.y = Mathf.Clamp(target.y, _minHeightMovement, _maxHeightMovement);
        return target;
    }
}
