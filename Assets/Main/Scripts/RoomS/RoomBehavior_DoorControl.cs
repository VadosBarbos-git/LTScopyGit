using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_DoorControl", menuName = "Game/DoorControlRoom")]
internal class RoomBehavior_DoorControl : RoomBaseBehavior, IOperableRoomBehavior
{
    public int EnergyCurent { get; set; }
    public int EnergyMax { get; set; }

    public bool CamThisEntityOperate(Entity entity)
    {
        return true;
    }

    public Sprite GetIconRoom()
    {
        return icon;
    }
}

