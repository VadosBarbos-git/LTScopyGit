

using UnityEngine;

public interface IOperableRoomBehavior : IHasEnergyRoom
{
    public void EntityExitFromRoom(Entity entiry);
    public bool CamThisEntityOperate(Entity entity);
    public void ActionOperable();
    public Sprite GetIconRoom();


}

