
using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Weapon", menuName = "Game/WeaponRoom")]
public class RoomBehavior_Weapon : RoomBaseBehavior, IOperableRoomBehavior
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
