
using UnityEngine;
using Zenject;

public class ShipController : MonoBehaviour
{
    [Inject] private RoomManager _roomManager;
    [Inject] private ShipUIDataView _shipUI;
    [Inject] private ShipVisual _visualElements;
    private void Start()
    {
        ShipData data = new(_roomManager.GetRooms());
        _shipUI.UodateAll(data);
        _shipUI.UpdateEnergyInRooms(data.GetAllRooms());
        _visualElements.ShowIconRooms(data.GetAllRooms());
    }
}
