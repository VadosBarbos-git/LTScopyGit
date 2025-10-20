using System.Collections.Generic;
using System.Linq;
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
