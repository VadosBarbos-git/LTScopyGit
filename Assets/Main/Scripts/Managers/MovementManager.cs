using System.Collections.Generic;
using System.Linq;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class MovementManager : MonoBehaviour
{
    [Inject] SelectionManager selectionManager;
    //[Inject] private DooreSystem _dooreSystem;
    [Inject] private RoomManager _roomManager;

    private Dictionary<IEntity, GameObject> _positionCharacters = new();
    public void TryToMove(GameObject boxPressed)
    {

        List<Entity> characters =
            selectionManager.GetSelectedCharacters().Where(a => a is Entity).Cast<Entity>().ToList();
        List<GameObject> boxes = new();
        boxes = FilterFreeBoxesInRoom(FindRoom(boxPressed), boxPressed);

        //метод который помещает MainColliderBox в начало если он есть в списке 
        boxes = SortCollidersForOperableRoom(boxes);

        for (int i = 0; i < boxes.Count; i++)
        {
            if (characters.Count <= i) break;

            Vector2 pos = boxes[i].transform.position;

            if (CanBuildPathThroughDoors(characters[i].moveComponent, pos))
            {
                _positionCharacters[characters[i]] = boxes[i];
                characters[i].Move(pos);
            }
        }

        selectionManager.Clear();
    }
    private List<GameObject> SortCollidersForOperableRoom(List<GameObject> allColloders)
    {
        if (allColloders.Count <= 0) return null;
        List<GameObject> result = new();
        DataRoom room = FindRoom(allColloders[0]);
        GameObject mainCollider = room.GetOperableSqureIfItOperableRoom();
        if (mainCollider == null || !allColloders.Contains(mainCollider))
            return allColloders;

        result.Add(mainCollider);
        for (int i = 0; i < allColloders.Count; i++)
        {
            if (!result.Contains(allColloders[i]))
                result.Add(allColloders[i]);
        }
        return result;
    }

    private DataRoom FindRoom(GameObject boxPressed)
    {
        List<DataRoom> rooms = _roomManager.GetRooms();

        foreach (DataRoom room in rooms)
            foreach (var box in room.GetCollidersFromData())
                if (box == boxPressed)
                    return room;

        return null;
    }
    private List<GameObject> FilterFreeBoxesInRoom(DataRoom room, GameObject boxPressed)
    {
        List<GameObject> result = new List<GameObject>();

        if (!ContainsNotSelectEntity(boxPressed))
            result.Add(boxPressed);

        foreach (var box in room.GetCollidersFromData())
        {
            if (!ContainsNotSelectEntity(box) && !result.Contains(box))
                result.Add(box);
        }
        return result;
    }
    private bool ContainsNotSelectEntity(GameObject value)
    {
        if (_positionCharacters.ContainsValue(value))
        {
            IEntity entity = null;
            foreach (var item in _positionCharacters)
            {
                if (item.Value == value)
                    entity = item.Key;
            }
            if (!selectionManager.GetSelectedCharacters().Contains(entity))
            {
                return true;
            }
        }
        return false;
    }
    private bool CanBuildPathThroughDoors(MovmentComponent moveC, Vector2 position)
    {
        NavMeshPath path = moveC.CalculatePath(position);
        if (path.status == NavMeshPathStatus.PathComplete) return true;
        return false;
    }
}
