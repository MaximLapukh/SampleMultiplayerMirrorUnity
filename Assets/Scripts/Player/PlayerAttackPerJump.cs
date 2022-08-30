using UnityEngine;

public class PlayerAttackPerJump
{
    private ScoreCounter _scoreCounter;
    private StatesManager _stateManager;
    public PlayerAttackPerJump(ScoreCounter scoreCounter, StatesManager statesManager)
    {
        _scoreCounter = scoreCounter;
        _stateManager = statesManager;
    }
    public void Attack(Collision collision)
    {
        if(collision.transform.TryGetComponent(out IDamagable damagable))
        {
            if(_stateManager.HaveStateOfType(typeof(JumpState)) && !_stateManager.HaveStateOfType(typeof(HurtState)))
            {
                if(damagable.TryDamage())
                    _scoreCounter.AddOneScore();
            }
        }
    }
}
