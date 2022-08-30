using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage 
{
    private StatesManager _statesManager;
    private float _timeHurt;
    public PlayerGetDamage(StatesManager statesManager, float timeHurt)
    {
        _statesManager = statesManager;
        _timeHurt = timeHurt;
    }
    public bool TryGetDamage()
    {
        if (_statesManager.HaveStateOfType(typeof(HurtState))) return false;
        if (_statesManager.HaveStateOfType(typeof(JumpState))) return false;
        HurtState hurtState = new HurtState(_timeHurt);
        _statesManager.AddState(hurtState);
        return true;
    }
}
