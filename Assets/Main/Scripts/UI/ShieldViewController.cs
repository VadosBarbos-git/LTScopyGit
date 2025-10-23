
using UnityEngine;
using UnityEngine.UI;

public class ShieldViewController : MonoBehaviour
{
    public GameObject[] ShieldsPoint = new GameObject[4];
    public Slider slider;

    [ContextMenu("UpdateShields")]
    public void UpdateShields(int activShields, float curentTimeBar, float maxTimeBar)
    {
        for (int i = 0; i < ShieldsPoint.Length; i++)
        {
            if (i < activShields)
                ShieldsPoint[i].SetActive(true);
            else
                ShieldsPoint[i].SetActive(false);
        }
        float valueSliderInProcents =  curentTimeBar /maxTimeBar;
        slider.value = valueSliderInProcents;
    }
}
