
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataRoom
{
    [SerializeField] private List<GameObject> Colliders = new();
    [SerializeField] private GameObject MainBoxColliderForOperable;

    public RoomBaseBehavior behavior;
    public List<GameObject> GetCollidersFromData() => Colliders;
    public GameObject GetOperableSqureIfItOperableRoom()
    {
        if (behavior != null && behavior is IOperableRoomBehavior)
        {
            if (MainBoxColliderForOperable == null)
                Debug.LogError("не добавлен MainBoxCollider в RoomData");
            else
                return MainBoxColliderForOperable; 
        }

        return null;
    }

}
