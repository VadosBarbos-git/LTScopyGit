

using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Shield", menuName = "Game/RoomShield")]
public class RoomBehavior_Shield : RoomBaseBehavior, IOperableRoomBehavior
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

