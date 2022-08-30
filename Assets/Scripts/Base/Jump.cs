using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump 
{
    private Rigidbody _rigidbody;
    private float _jumpPower;
    public Jump(Rigidbody rigidbody, float jumpPower)
    {
        _rigidbody = rigidbody;
        _jumpPower = jumpPower;
    }
    public void JumpDirection(Vector3 direction)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(direction * _jumpPower, ForceMode.Impulse);
    }
}
