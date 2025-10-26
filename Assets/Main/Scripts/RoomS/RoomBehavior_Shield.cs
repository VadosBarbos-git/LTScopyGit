

using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Shield", menuName = "Game/RoomShield")]
public class RoomBehavior_Shield : OperateRoomBehavior
{
    public override void ActionOperable()
    {
        base.ActionOperable();
        ChargeShields();
    }
    private void ChargeShields()
    {
        dataRoom.shipController.ChargeShields(curentEntity);
    }
    public override void EntityExitFromRoom(Entity entiry)
    {
        base.EntityExitFromRoom(entiry);
        if (curentEntity == null)
            dataRoom.shipController.ChargeShields(null, true);
    }
}

