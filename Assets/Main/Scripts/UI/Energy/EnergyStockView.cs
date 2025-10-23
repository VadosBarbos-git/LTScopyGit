using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStockView : MonoBehaviour
{
    public VerticalLayoutGroup layoutGroup;
    public GameObject parentPoints;
    public void UpdateStockEnergyView(int MaxEnergy, int energyInStack)
    {
        layoutGroup.enabled = true;

        for (int i = parentPoints.transform.childCount; i < MaxEnergy; i++)
        {
            Instantiate(parentPoints.transform.GetChild(0), parentPoints.transform);
        }
        for (int i = parentPoints.transform.childCount - 1; i >= MaxEnergy; i--)
        {
            Destroy(parentPoints.transform.GetChild(i).gameObject);
        }

        StartCoroutine(UpdateVisualBar(energyInStack));
        StartCoroutine(closeLayoutGroupe());
    }
    private IEnumerator closeLayoutGroupe()
    {
        yield return null;
        yield return null;
        yield return null;
        layoutGroup.enabled = false;
    }
    private IEnumerator UpdateVisualBar(int curentBar)
    {
        yield return null;
        yield return null;

        for (int i = 0; i < parentPoints.transform.childCount; i++)
        {
            Image image = parentPoints.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            if (i < curentBar)
                image.enabled = true;
            else
                image.enabled = false;
        }
    }
}
