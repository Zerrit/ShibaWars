using PathCreation;
using UnityEngine;

[CreateAssetMenu(fileName = "Barricade", menuName = "Ability/BarricadeAbility")]
public class Barricade : Ability
{
    public GameObject barricade;

    public override bool UseAbility(Vector2 touchPoint)
    {
        Vector2 way = BattleCommunicator.instance.GetPositionByX(Camera.main.ScreenToWorldPoint(touchPoint));

        if (BattleCommunicator.instance)
        {
            Instantiate(barricade, way, Quaternion.identity);
            return true;
        }
        else return false;
    }
}
