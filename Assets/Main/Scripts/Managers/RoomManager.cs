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
    public DataRoom GetRoomByPosition(Vector2 position)
    {
        for (int i = 0; i < Rooms.Count; i++)
        {
            List<GameObject> ObjColliders = Rooms[i].GetCollidersFromData();
            for (int j = 0; j < ObjColliders.Count; j++)
            {
                BoxCollider2D box = ObjColliders[j].GetComponent<BoxCollider2D>();
                if (box != null && IsPointInsideBox(box, position))
                    return Rooms[i];
            }
        }
        return null;
    }
    private bool IsPointInsideBox(BoxCollider2D box, Vector2 point)
    {
        // ѕереводим точку в локальные координаты бокса
        Vector2 localPoint = box.transform.InverseTransformPoint(point);

        Vector2 halfSize = box.size * 0.5f;

        return localPoint.x >= -halfSize.x &&
               localPoint.x <= halfSize.x &&
               localPoint.y >= -halfSize.y &&
               localPoint.y <= halfSize.y;
    }
}
