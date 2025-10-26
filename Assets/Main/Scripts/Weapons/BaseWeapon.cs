using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_", menuName = "Weapon/BaseWeapon")]
public class BaseWeapon : ScriptableObject, IWeapon
{
    [SerializeField] private string nameWeapon;
    [SerializeField] private Sprite icon;
    [SerializeField] private float timeForCharge;
    [SerializeField] private float damage;
    [SerializeField] private int needEnergy;

    public float TimeForCharge { get => timeForCharge; set { } }
    public string NameWeapon { get => nameWeapon; set { } }
    public float Damage { get => damage; set { } }

    public int EnergyNeeded { get => needEnergy; set {; } }

    public Sprite GetIcon() => icon;
}
