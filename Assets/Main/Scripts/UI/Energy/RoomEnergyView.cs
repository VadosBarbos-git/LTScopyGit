using UnityEngine;
using UnityEngine.UI;

public class RoomEnergyView : MonoBehaviour
{
    public EnergyStockView energyStockView;
    public Image IconRoom;
    public Image BkRoomIconWithEnergy;
    public void UpdateEnergyViewInRoom(Sprite iconRoom, int MaxEnergy, int energyInRoom)
    {
        energyStockView.UpdateStockEnergyView(MaxEnergy, energyInRoom);
        VisualIconRoom(iconRoom, energyInRoom);
    }
    private void VisualIconRoom(Sprite iconRoom, int energyInRoom)
    {
        IconRoom.sprite = iconRoom;
        BkRoomIconWithEnergy.enabled = energyInRoom > 0;
    }
}
