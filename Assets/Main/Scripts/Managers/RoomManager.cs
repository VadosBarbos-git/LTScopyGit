using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<DataRoom> Rooms = new();
    public List<DataRoom> GetRooms()
    {
        List<DataRoom> result = new List<DataRoom>();
        result.AddRange(Rooms);
        return result;
    }
}
