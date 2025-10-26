
using System.Collections.Generic;
using UnityEngine; 
using Zenject;

public class ShipController : MonoBehaviour
{
    private RoomManager _roomManager;
    [Inject] private ShipUIDataView _shipUI;
    [Inject] private ShipVisual _visualElements;
    private ShipData _shipData;
    private float _deltaTime = 0f;
    private bool pause = false;
    private float finalSpeedChargeShields = -1;
    private float finalSpeedChargeWeapon = -1;
    private void Awake()
    {
        _roomManager = GetComponentInChildren<RoomManager>();
        _shipData = new(SetShipControlerAndDataRoom(_roomManager.GetRooms()));
    }

    private void Start()
    {
        _shipUI.UodateAll(_shipData);
        _shipUI.UpdateEnergyInRooms(_shipData.GetAllRooms());
        _visualElements.ShowIconRooms(_shipData.GetAllRooms());
    }
    private void Update()
    {
        if (!pause)
        {
            _deltaTime = Time.deltaTime;
            Shields();
        }
        else
            _deltaTime = 0;

    }
    private List<DataRoom> SetShipControlerAndDataRoom(List<DataRoom> rooms)
    {
        rooms.ForEach(a => a.SetShipControler(this));
        foreach (var item in rooms)
        {
            if (item.behavior != null)
                item.behavior.SetDataRoom(item);
        }
        // rooms.ForEach(a => a.behavior.SetDataRoom(a));
        return rooms;
    }

    #region ActionsFromRoomsBehavior
    //All this voids works in Update
    public void ChargeShields(Entity curentEntity, bool stop = false)
    {
        if (stop)
            finalSpeedChargeShields = -1;
        else
        {
            float modSpeedFromEntity = 1;//0.5...2
            finalSpeedChargeShields = ShipData.speedUpdateShields * modSpeedFromEntity;
        }
    }

    public void WeaponCharge(Entity curenEntity, bool stop = false)
    {
        if (stop)
            finalSpeedChargeWeapon = -1;
        else
        {
            float modSpeedFromEntity = 1;//0.5...2
            finalSpeedChargeWeapon = ShipData.speedUpdateWeapon * modSpeedFromEntity;
        }
    }
    #endregion
    private void Shields()
    {
        if (_shipData.maxShieldValue <= _shipData.curentShieldsValue) return;
        if (_shipData.curentTimeForUpdateShield >= _shipData.finishTimeForUpdateShields)
        {
            _shipData.curentShieldsValue += 1;
            _shipData.curentTimeForUpdateShield = 0;
        }
        _shipData.curentTimeForUpdateShield =
            Mathf.Clamp(_shipData.curentTimeForUpdateShield + _deltaTime * finalSpeedChargeShields, 0, _shipData.finishTimeForUpdateShields);
        _shipUI.UpdateShields(_shipData.curentShieldsValue, _shipData.curentTimeForUpdateShield, _shipData.finishTimeForUpdateShields);

    }
    private void Weapon()
    {
        //увеличиваем время заряда всего оружия 
        //класс оружия и список из него 
    }
}
