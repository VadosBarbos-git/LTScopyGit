
using UnityEngine;

public class OperateRoomBehavior : RoomBaseBehavior, IOperableRoomBehavior
{
    protected Entity curentEntity;
    public int EnergyCurent { get; set; }
    public int EnergyMax { get; set; }

    public virtual bool CamThisEntityOperate(Entity entity)
    {
        if (curentEntity == null || curentEntity == entity)
        {
            curentEntity = entity;
            return true;
        }
        return false;
    }

    public virtual void EntityExitFromRoom(Entity entiry)
    {
        if (entiry == curentEntity)
            curentEntity = null;
    }

    public Sprite GetIconRoom()
    {
        return icon;
    }
    public virtual void ActionOperable() { }
}

