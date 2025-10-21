using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Cockpit", menuName = "Game/Cockpit")]
public class RoomBehavior_Cockpit : RoomBaseBehavior, IOperableRoomBehavior
{
    public float Energy { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public bool CamThisEntityOperate(Entity entity)
    {
        throw new System.NotImplementedException();
    }
}
