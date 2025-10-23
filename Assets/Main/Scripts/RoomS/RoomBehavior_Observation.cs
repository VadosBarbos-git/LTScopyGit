using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Observation", menuName = "Game/ObservationRoom")]
internal class RoomBehavior_Observation : RoomBaseBehavior, IOperableRoomBehavior
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

