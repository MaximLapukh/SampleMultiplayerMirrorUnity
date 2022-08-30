using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump01 : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _longJump;
    private float _timeJump;
    private float _speed;

    private float _timer;

    private Vector3 _velocity;
    public void Init(Rigidbody rigidbody, float longJump, float timeJump)
    {
        _rigidbody = rigidbody;
        _longJump = longJump;
        _timeJump = timeJump;
        _speed = _longJump / _timeJump;
    }
    public void JumpTo(Vector3 direction)
    {
        _velocity = direction * _speed;
        _timer = _timeJump;
    }
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _rigidbody.velocity = _velocity;
        }
        if (_timer < 0)
        {
            _rigidbody.velocity = Vector3.zero;
            _timer = 0;
        }
    }
}
