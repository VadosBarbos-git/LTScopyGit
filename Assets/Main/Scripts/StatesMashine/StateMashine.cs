
using System;
using System.Collections.Generic; 

public class StateMashine
{
    public EntityState curentState;
    private Dictionary<Type, EntityState> allStats = new();
    private EntityState nextState;
    private bool canChangeState = true;

    public void ChangeState<T>()
    {
        if (!canChangeState) return;
        Type type = typeof(T);
        if (allStats.ContainsKey(type))
        {
            nextState = allStats[type];
        }
    }
    public void AddState(EntityState state)
    {
        allStats.Add(state.GetType(), state);
    }
    public void UpdateCurentState()
    {
        SetCurentStateAfterFrame();
        curentState?.Update();
    }
    public void SwitchOffStateMashine() =>canChangeState = false;
    private void SetCurentStateAfterFrame()
    {
        if (!canChangeState) return;
        if (nextState != null)
        {
            curentState?.Exit();
            curentState = nextState;
            curentState?.Enter();
            nextState = null;
        }
    }

}
