using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ShipView : MonoBehaviour
{
    [Header("HullBar")]
    public int maxHelthBar = 10;
    public int curenHelthBar = 8;
    [Header("Shield")]
    public int shieldsValue = 2;
    public float curentTime = 1f;
    public float maxTime = 4f;
    [Header("Oxygen/Maneuverability")]
    public float maneuverability = 15f;//%
    public float oxygen = 90;//%
    [Header("EnergyStack")]
    public int maxEnergy = 8;
    public int energyInStack = 6;
    [Header("Dpendencies")]
    public TextMeshProUGUI ManeuverabilityText;
    public TextMeshProUGUI OxygenText;
    public HullStrengthBarController HullBarControler;
    public ShieldViewController ShieldController;
    public EnergyStockView energy;
    public StockRoomsEnergyControlerView StockRoomsEnergyControler; 

     
    public void UpdateHullBar()
    {
        if (HullBarControler != null)
        {
            HullBarControler.UpdatePointsView(curenHelthBar, maxHelthBar);
        }
    } 
    public void UpdateShields()
    {
        ShieldController.UpdateShields(shieldsValue, curentTime, maxTime);
    } 
    public void UpdateOxygen()
    {
        OxygenText.text = $"{oxygen}%";
    }
    
    public void UpdateManeuverablity()
    {
        ManeuverabilityText.text = $"{maneuverability}%";
    }
    
    public void UpdateEnergyStack()
    {
        energy.UpdateStockEnergyView(maxEnergy, energyInStack);
    } 
    public void UpdateEnergyInRooms(HashSet<DataRoom>Allrooms)
    {  
        StockRoomsEnergyControler.UpdateEnergyInRooms(Allrooms);
    } 
    public void UodateAll()
    {
        UpdateManeuverablity();
        UpdateOxygen();
        UpdateShields();
        UpdateHullBar();
        UpdateEnergyStack(); 
    }


}
