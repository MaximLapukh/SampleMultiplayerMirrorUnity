using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving 
{
    private Moving _moving;
    private StatesManager _stateManager;
    public PlayerMoving(Moving moving, StatesManager statesManager)
    {
        _moving = moving;
        _stateManager = statesManager;
    }
    public void MoveDirection(Vector3 direction)
    {
        if (_stateManager.HaveStateOfType(typeof(JumpState))) return;

        _moving.Move(direction.normalized);
    }
}
