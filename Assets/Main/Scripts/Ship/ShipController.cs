using UnityEngine;
using Zenject;

public class ShipController : MonoBehaviour
{
    [Inject] private RoomManager _roomManager;
    [Inject] private ShipView _shipView;
    private void Start()
    {
        ShipData data = new();
        data.SetAllRooms(_roomManager.GetRooms());
        _shipView.UodateAll();
        _shipView.UpdateEnergyInRooms(data.GetAllRooms());
    }
}
