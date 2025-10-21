using UnityEngine;

public class ShipView : MonoBehaviour
{
    public int MaxHelthBar = 10;
    public int CurenHelthBar = 8;
    public HullStrengthBarController HullBarControler;


   /* private void OnValidate()
    {
        if (HullBarControler != null)
        {
            HullBarControler.UpdatePointsView(CurenHelthBar, MaxHelthBar);
        }
    }*/

}
