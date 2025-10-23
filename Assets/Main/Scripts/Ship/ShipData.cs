
using System.Collections.Generic;
using Unity.VisualScripting;

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
    public float curentTimeForUpdateShield;
    public float finishTimeForUpdateShields;
    public float speedUpdateShields;
    #endregion

    #region Others 
    public float maneuverability;//%
    public float oxygen; //%
    #endregion
    public ShipData(List<DataRoom> rooms)
    {
        SetAllRooms(rooms);
        ClearAllRoomsSomeData();
        maxEnergyForShip = 8;
        curenEnergyInShipStock = 8;

        maxHelthShip = 14;
        curentHelthShip = 14;
         
        curentShieldsValue = 0;
        maxShieldValue = 1;
        curentTimeForUpdateShield = 0;
        finishTimeForUpdateShields = 5;
        speedUpdateShields = 1; 

        maneuverability = 0;//%
        oxygen = 100; //%


    }
    public HashSet<DataRoom> GetAllRooms() => AllRooms;
    public HashSet<DataRoom> GetOperableRooms() => OperabelsRooms;


    private HashSet<DataRoom> AllRooms = new();
    private HashSet<DataRoom> OperabelsRooms = new();

    private void SetAllRooms(List<DataRoom> rooms)
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
    private void ClearAllRoomsSomeData()
    {
        foreach (var room in AllRooms)
        {
            if(room.behavior is IOperableRoomBehavior operRoom)
            {
                operRoom.EnergyCurent = 0;
                operRoom.EnergyMax = 2;
            }
        }
    }

}
