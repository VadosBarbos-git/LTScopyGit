
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipData
{
    #region Energy
    public int maxEnergyForShip;
    public int curenEnergyInShipStock;
    #endregion

    #region HelthShip
    public int maxHelthShip;
    public int curentHelthShip;
    #endregion

    #region Shields
    public int curentShieldsValue;
    public int maxShieldValue;
    //public float 
    #endregion

    
    public float curentTime = 1f;
    public float maxTime = 4f;
    [Header("Oxygen/Maneuverability")]
    public float maneuverability = 15f;//%
    public float oxygen = 90;//%


    private HashSet<DataRoom> AllRooms = new();
    private HashSet<DataRoom> OperabelsRooms = new();
    public HashSet<DataRoom> GetAllRooms() => AllRooms;
    public HashSet<DataRoom> GetOperableRooms() => OperabelsRooms;
    public void SetAllRooms(List<DataRoom> rooms)
    {
        AllRooms.Clear();
        AllRooms.AddRange(rooms);
        SetOperableRooms();
    }
    private void SetOperableRooms()
    {
        OperabelsRooms.Clear();
        foreach (var item in AllRooms)
        {
            if (item.behavior is IOperableRoomBehavior)
                OperabelsRooms.Add(item);
        }
    }

}
