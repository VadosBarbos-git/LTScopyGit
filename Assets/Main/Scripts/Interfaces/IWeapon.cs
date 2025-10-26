
using UnityEngine;

public interface IWeapon
{
    public string NameWeapon { get; set; }
    public float TimeForCharge { get; set; }
    public float Damage { get; set; }
    public int EnergyNeeded { get; set; }
    public Sprite GetIcon();
}

