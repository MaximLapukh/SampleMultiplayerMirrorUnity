using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving 
{
    private Rigidbody _rigidbody;
    private float _speed;
    public Moving(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }
    public void Move(Vector3 direction)
    {
        if (direction == Vector3.zero) return;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.deltaTime);
    }
}
