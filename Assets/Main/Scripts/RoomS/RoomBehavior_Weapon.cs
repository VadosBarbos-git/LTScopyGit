
using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Weapon", menuName = "Game/WeaponRoom")]
public class RoomBehavior_Weapon : OperateRoomBehavior
{
    public override void ActionOperable()
    {
        base.ActionOperable();
        ChargeWeapon();
    }
    private void ChargeWeapon()
    {
        dataRoom.shipController.WeaponCharge(curentEntity);
    }
    public override void EntityExitFromRoom(Entity entiry)
    {
        base.EntityExitFromRoom(entiry);
        if (curentEntity == null)
            dataRoom.shipController.WeaponCharge(null, true);
    }
}
