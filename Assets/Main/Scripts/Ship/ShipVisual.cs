using System.Collections.Generic;
using UnityEngine;

public class ShipVisual : MonoBehaviour
{
    public GameObject SpritePrefab;
    public GameObject parentForIconRoooms;
    public void ShowIconRooms(HashSet<DataRoom> Rooms)
    {
        foreach (var room in Rooms)
        {
            if (room.behavior is not IOperableRoomBehavior operable)
                continue;
            Sprite sprite = operable.GetIconRoom();
            List<GameObject> colliders = room.GetCollidersFromData();

            int count = colliders.Count;
            if (count <= 0) throw new System.Exception("Чтото не так с колайдерами в RoomManager");

            Vector2 allPoints = Vector2.zero;
            for (int i = 0; i < count; i++)
            {
                allPoints += new Vector2(colliders[i].transform.position.x, colliders[i].transform.position.y);
            }
            Vector2 posForSprite = allPoints / count;

            GameObject obj = Instantiate(SpritePrefab, parentForIconRoooms.transform);

            obj.transform.position = posForSprite;
            obj.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

}
