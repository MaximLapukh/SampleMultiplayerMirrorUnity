using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump 
{
    private Jump _jump;
    private Rigidbody _rigidbody;
    private StatesManager _stateManager;
    private Camera _camera;
    private float _longJump;
    public PlayerJump(Jump jump, Rigidbody rigidbody, StatesManager stateManager, Camera camera, float longJump)
    {
        _jump = jump;
        _rigidbody = rigidbody;
        _stateManager = stateManager;
        _camera = camera;
        _longJump = longJump;
    }
    /* DEPRECATED ALL
    public void Jump(Vector3 mousePostiion)
    {
        
        if (_stateManager.HaveStateOfType(typeof(JumpState))) return;
        Ray ray = _camera.ScreenPointToRay(mousePostiion);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _jump.JumpDirection((hit.point - _rigidbody.position).normalized);
            JumpState jumpState = new JumpState();//set long of time
            _stateManager.AddState(jumpState);
        }
        
    }*/
}
