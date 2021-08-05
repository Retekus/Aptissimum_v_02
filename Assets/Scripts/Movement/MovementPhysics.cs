using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhysics : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody{ set { _rigidbody = value; } }

    private float _speed;
    public float Speed { set { _speed = value; } }

    public void Move(Vector3 offset)
    {
        Vector3 moveInput = _rigidbody.position + offset * _speed * Time.deltaTime;
        _rigidbody.MovePosition(moveInput);
    }
}
