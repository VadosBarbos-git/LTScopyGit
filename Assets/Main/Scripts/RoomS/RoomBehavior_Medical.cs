using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Medical", menuName = "Game/MedicalRoom")]
public class RoomBehavior_Medical : RoomBaseBehavior, IOperableRoomBehavior
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
