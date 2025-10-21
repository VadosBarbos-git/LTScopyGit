
public class OperateRoom_StateEntity : EntityState
{
    public OperateRoom_StateEntity(StateMashine stateMashine, Entity entity) : base(stateMashine, entity)
    {
    }
    public override void Update()
    {
        base.Update();
        if (entity.curenRoom == null || entity.curenRoom.behavior == null
            || entity.curenRoom.behavior is not IOperableRoomBehavior operableRoom
            || !operableRoom.CamThisEntityOperate(entity))
        {
            stateMashine.ChangeState<Idle_StateEntity>();
        }
    }

}
