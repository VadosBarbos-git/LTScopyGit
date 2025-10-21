
public class Idle_StateEntity : EntityState
{
    public Idle_StateEntity(StateMashine stateMashine, Entity entity) : base(stateMashine, entity)
    {
    }
    public override void Update()
    {
        base.Update();
        if (entity.curenRoom != null && entity.curenRoom.behavior != null)
        {
            if (entity.curenRoom.behavior is IOperableRoomBehavior interectRoom
                && interectRoom.CamThisEntityOperate(entity))
                stateMashine.ChangeState<OperateRoom_StateEntity>();
        }
    }
}
