using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatesManager 
{
    private List<State> _states = new List<State>();
    public void AddState(State state)
    {
        state.Begin();
        state.OverEvent += RemoveState;
        _states.Add(state);
    }
    public void RemoveState(State state)
    {
        if (_states.Contains(state))
            _states.Remove(state);
    }
    public bool HaveStateOfType(Type state)
    {
        foreach (var item in _states)
        {
            if (item.GetType() == state) return true;
        }
        return false;
    }
    public bool HaveState(State state)
    {
        return _states.Contains(state);
    }
    public void Update()
    {
        foreach (var stateItem in _states.ToArray()) //think: ToArray look bad
        {
            stateItem.OnUpdate();
        }
    }
}
