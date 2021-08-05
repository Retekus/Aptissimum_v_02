using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    private float _horizontalAxis, _verticalAxis;

    [SerializeField]
    private Camera _camera;
    [SerializeField, Range(1, 10)]
    private float _speed;
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private MovementPhysics _movementPhysics;
    [SerializeField]
    private Rotation _rotationScript;

    private void Awake()
    {
        _movementPhysics.Rigidbody = _rigidbody;
        _rotationScript.Camera = _camera;
    }

    void FixedUpdate()
    {
        _movementPhysics.Speed = _speed;

        _horizontalAxis = Input.GetAxis("Horizontal");
        _verticalAxis = Input.GetAxis("Vertical");

        Vector3 inputAxis = new Vector3(_horizontalAxis, 0f, _verticalAxis);
        Vector3 pointToLook = _rotationScript.GetPointToLook();

        _movementPhysics.Move(inputAxis);
        transform.LookAt(pointToLook);
    }


}
