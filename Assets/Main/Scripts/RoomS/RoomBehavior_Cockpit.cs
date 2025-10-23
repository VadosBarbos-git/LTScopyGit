using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Cockpit", menuName = "Game/Cockpit")]
public class RoomBehavior_Cockpit : RoomBaseBehavior, IOperableRoomBehavior
{
    public int EnergyCurent { get; set; } = 2;
    public int EnergyMax { get; set; } = 4;
    public bool CamThisEntityOperate(Entity entity)
    {
        return true;
    }

    public Sprite GetIconRoom()
    {
        return icon;
    }
}
