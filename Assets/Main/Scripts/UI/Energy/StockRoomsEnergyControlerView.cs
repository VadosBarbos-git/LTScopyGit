using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StockRoomsEnergyControlerView : MonoBehaviour
{
    public GameObject prefabRoomEnergyView;
    public GameObject parentRooms;
    private HorizontalLayoutGroup _layoutForRooms;
    private Dictionary<IOperableRoomBehavior, RoomEnergyView> _allRoomsViewEnetgy = new();
    private void Awake()
    {
        _layoutForRooms = parentRooms.GetComponent<HorizontalLayoutGroup>();
    }
    public void UpdateEnergyInRooms(HashSet<DataRoom> operableRooms)
    {
        _layoutForRooms.enabled = true;
        List<IOperableRoomBehavior> rooms = new();
        foreach (var item in operableRooms)
        {
            if (item.behavior is IOperableRoomBehavior operable)
                rooms.Add(operable);
        }
        AddAndDestroyRoomsView(operableRooms, rooms);
        StartCoroutine(UpdateViewRooms(rooms));
        StartCoroutine(CloseLayout());
    }

    private void AddAndDestroyRoomsView(HashSet<DataRoom> operableRooms, List<IOperableRoomBehavior> rooms)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (!_allRoomsViewEnetgy.ContainsKey(rooms[i]))
            {
                GameObject obj = Instantiate(prefabRoomEnergyView, parentRooms.transform);
                RoomEnergyView roomView = obj.GetComponent<RoomEnergyView>();
                _allRoomsViewEnetgy.Add(rooms[i], roomView);
            }
        }
        List<IOperableRoomBehavior> keysToRemuve = new();
        foreach (var item in _allRoomsViewEnetgy)
        {
            if (!rooms.Contains(item.Key))
            {
                keysToRemuve.Add(item.Key);
                Destroy(item.Value.gameObject);
            }
        }
        foreach (var key in keysToRemuve)
        {
            _allRoomsViewEnetgy.Remove(key);
        }
    }
    private IEnumerator UpdateViewRooms(List<IOperableRoomBehavior> rooms)
    {
        yield return null;
        yield return null;
        foreach (var item in _allRoomsViewEnetgy)
        {
            IOperableRoomBehavior curentRoom = rooms.First(a => a == item.Key);
            Sprite spr = curentRoom.GetIconRoom();
            int maxEnergy = curentRoom.EnergyMax;
            int curentEnergy = curentRoom.EnergyCurent;
            item.Value.UpdateEnergyViewInRoom(spr, maxEnergy, curentEnergy);
        }
    }
    private IEnumerator CloseLayout()
    {
        yield return null;
        yield return null;
        _layoutForRooms.enabled = false;

    }

}
