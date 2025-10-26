using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSection : MonoBehaviour
{
    [SerializeField] private Color ActivColorText;
    [SerializeField] private Color NotActivColorText;
    [SerializeField] private TextMeshProUGUI NameWeapon;
    [SerializeField] private EnergyStockView energyView;
    [SerializeField] private Slider timeBar;
    [SerializeField] private RectTransform barRect;
    [SerializeField] private float baseSceleXBar = 0.294f;
    public void UpdateWeaponSection()
    {

    }

}
