using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipUIDataView : MonoBehaviour
{

    public TextMeshProUGUI ManeuverabilityText;
    public TextMeshProUGUI OxygenText;
    public HullStrengthBarController HullBarControler;
    public ShieldViewController ShieldController;
    public EnergyStockView energy;
    public StockRoomsEnergyControlerView StockRoomsEnergyControler;


    public void UpdateHullBar(int curentHelthShip, int maxHelthShip)
    {
        if (HullBarControler != null)
        {
            HullBarControler.UpdatePointsView(curentHelthShip, maxHelthShip);
        }
    }
    public void UpdateShields(int curentShieldsValue, float curentTime, float finishTime)
    {
        ShieldController.UpdateShields(curentShieldsValue, curentTime, finishTime);
    }
    public void UpdateOxygen(float oxygen)
    {
        OxygenText.text = $"{Mathf.Round(oxygen)}%";
    }

    public void UpdateManeuverablity(float maneuverability)
    {
        ManeuverabilityText.text = $"{maneuverability}%";
    }

    public void UpdateEnergyStack(int maxEnergyForShip, int curenEnergyInShipStock)
    {
        energy.UpdateStockEnergyView(maxEnergyForShip, curenEnergyInShipStock);
    }
    public void UpdateEnergyInRooms(HashSet<DataRoom> Allrooms)
    {
        StockRoomsEnergyControler.UpdateEnergyInRooms(Allrooms);
    }
    public void UodateAll(ShipData data)
    {
        UpdateManeuverablity(data.maneuverability);
        UpdateOxygen(data.oxygen);
        UpdateShields(data.curentShieldsValue, data.curentTimeForUpdateShield, data.finishTimeForUpdateShields);
        UpdateHullBar(data.curentHelthShip, data.maxHelthShip);
        UpdateEnergyStack(data.maxEnergyForShip, data.curenEnergyInShipStock);
    }


}
