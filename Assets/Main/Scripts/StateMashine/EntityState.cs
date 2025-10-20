
using UnityEngine;

public class EntityState 
{
    protected StateMashine stateMashine;
    protected Animator animator;
    private string animName;
    protected float timerState;
    public EntityState(StateMashine stateMashine,Entity entity)
    {
        this.stateMashine = stateMashine;
        this.animator = entity.animator;
        animName = GetType().ToString();
    }
    public virtual void Update()
    {
        timerState += Time.deltaTime;
    }
    public virtual  void Enter()
    {
        timerState = 0;
        animator.SetBool(animName,true);
    }
    public virtual void Exit()
    {
        animator.SetBool(animName, false);
    }
   

}
