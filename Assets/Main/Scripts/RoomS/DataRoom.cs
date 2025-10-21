
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataRoom
{
    [SerializeField] private List<GameObject> Colliders = new();

    public RoomBaseBehavior bechavior;
    public List<GameObject> GetCollidersFromData() => Colliders;

}
