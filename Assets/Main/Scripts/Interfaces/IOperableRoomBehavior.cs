

using UnityEngine;

public interface IOperableRoomBehavior : IHasEnergyRoom
{
    public bool CamThisEntityOperate(Entity entity);
    public Sprite GetIconRoom();

}

