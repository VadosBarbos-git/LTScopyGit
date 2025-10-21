
public class OperateRoom_StateEntity : EntityState
{
    public OperateRoom_StateEntity(StateMashine stateMashine, Entity entity) : base(stateMashine, entity)
    {
    }
    public override void Update()
    {
        base.Update();
        if (entity.curenRoom == null || entity.curenRoom.bechavior == null
            || entity.curenRoom.bechavior is not IOperableRoomBehavior operableRoom
            || !operableRoom.CamThisEntityOperate(entity))
        {
            stateMashine.ChangeState<Idle_StateEntity>();
        }
    }

}
