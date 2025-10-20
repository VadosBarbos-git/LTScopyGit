
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataRoom
{
    [SerializeField] private List<GameObject> Colliders = new();
    public RoomScriptableObject roomObject; 
    public List<GameObject> GetCollidersFromData() => Colliders;

}
