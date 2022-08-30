using System;

public abstract class State
{
    public event Action<State> OverEvent = delegate { };
    public abstract void Begin();
    public abstract void OnUpdate();
    public virtual void Over()
    {
        OverEvent.Invoke(this);
    }
}