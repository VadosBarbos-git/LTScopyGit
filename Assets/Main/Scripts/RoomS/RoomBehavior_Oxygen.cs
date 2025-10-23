using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Oxygen", menuName = "Game/OxygenRoom")]
public class RoomBehavior_Oxygen : RoomBaseBehavior, IOperableRoomBehavior
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
