
using UnityEngine;

[CreateAssetMenu(fileName = "RoomBehavior_Weapon", menuName = "Game/WeaponRoom")]
public class RoomBehavior_Weapon : RoomBaseBehavior, IOperableRoomBehavior
{
    public float Energy { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public bool CamThisEntityOperate(Entity entity)
    {
        return true;
    }
}
