
using UnityEngine;

public class EntityState
{
    protected StateMashine stateMashine;
    protected Animator animator;
    protected Entity entity;
    protected float timerState;

    private string animName;
    public EntityState(StateMashine stateMashine, Entity entity)
    {
        this.stateMashine = stateMashine;
        this.entity = entity;
        animator = entity.animator;
        animName = GetType().ToString();
    }
    public virtual void Update()
    {
        timerState += Time.deltaTime;
    }
    public virtual void Enter()
    {
        timerState = 0;
        animator.SetBool(animName, true);
    }
    public virtual void Exit()
    {
        animator.SetBool(animName, false);
    }


}
