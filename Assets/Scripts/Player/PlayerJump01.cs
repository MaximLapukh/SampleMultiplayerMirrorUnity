using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//thinks: use dash instead jump
public class PlayerJump01 
{
    private Jump01 _jump;
    private Rigidbody _rigidbody;
    private StatesManager _stateManager;
    private JumpState _jumpState;
    private float _timeJump;
    public PlayerJump01(Jump01 jump, Rigidbody rigidbody, StatesManager stateManager, float timeJump)
    {
        _jump = jump;
        _rigidbody = rigidbody;
        _stateManager = stateManager;
        _timeJump = timeJump;
    }
    public void Jump(Vector3 pointClick)
    {
        if (_stateManager.HaveStateOfType(typeof(JumpState))) return;

        _jump.JumpTo((pointClick - _rigidbody.position).normalized);
        _jumpState = new JumpState(_timeJump);
            
        _stateManager.AddState(_jumpState);
    }
}

