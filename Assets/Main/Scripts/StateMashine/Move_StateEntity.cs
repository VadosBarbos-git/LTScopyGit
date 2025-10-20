 
public class Move_StateEntity : EntityState
{
    private MovmentComponent _movmentComponent;
    public Move_StateEntity(StateMashine stateMashine, Entity entity) : base(stateMashine, entity)
    {
        _movmentComponent = entity.moveComponent;
    }
 
    public override void Update()
    {
        ChechStopAgent();
    }
    private void ChechStopAgent()
    {
        if (!_movmentComponent.IsMovingEntity())
        {
            stateMashine.ChangeState<Idle_StateEntity>();
        }
    }
}
