using UnityEngine;

public class HurtState : State
{
    private float _hurtTime;
    private float _timer;
    public HurtState(float hurtTime)
    {
        _hurtTime = hurtTime;
    }
    public override void Begin()
    {
        _timer = _hurtTime;
    }

    public override void OnUpdate()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0) Over();
    }

}
