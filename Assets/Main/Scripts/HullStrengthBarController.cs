using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HullStrengthBarController : MonoBehaviour
{
    public GameObject parentPoints;
    private HorizontalLayoutGroup layoutGroup;
    private void Awake()
    {
        layoutGroup = parentPoints.GetComponent<HorizontalLayoutGroup>();
    }
    public void UpdatePointsView(int CurentValue, int maxValue)
    {
        if (maxValue <= 0) return;
        if (CurentValue > maxValue) return;

        layoutGroup.enabled = true;

        for (int i = parentPoints.transform.childCount; i < maxValue; i++)
        {
            Instantiate(parentPoints.transform.GetChild(0), parentPoints.transform);
        }
        for (int i = parentPoints.transform.childCount - 1; i >= maxValue; i--)
        {
            Destroy(parentPoints.transform.GetChild(i).gameObject);
        }

        StartCoroutine(UpdateVisualBar(CurentValue));
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
            Image image = parentPoints.transform.GetChild(i).GetComponent<Image>();
            if (i < curentBar)
                image.enabled = true;
            else
                image.enabled = false;
        }
    }


}
