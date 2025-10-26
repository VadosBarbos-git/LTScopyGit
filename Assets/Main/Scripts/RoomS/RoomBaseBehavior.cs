
using UnityEngine;
public abstract class RoomBaseBehavior : ScriptableObject, IRoomBehavior
{
    protected DataRoom dataRoom;
    public Sprite icon;
    public void SetDataRoom(DataRoom dataRoom) => this.dataRoom = dataRoom;
}
