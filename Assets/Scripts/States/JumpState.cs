using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private float _timeJump;
    private float _timer;
    public JumpState(float timeJump)
    {
        _timeJump = timeJump;
    }
    public override void Begin()
    {
        _timer = _timeJump;
    }

    public override void OnUpdate()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0) Over();
    }

}
