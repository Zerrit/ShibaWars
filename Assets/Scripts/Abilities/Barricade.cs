using UnityEngine;

[CreateAssetMenu(fileName = "Barricade", menuName = "Ability/BarricadeAbility")]
public class Barricade : Ability
{
    public BarricadeObject barricade;

    public override bool UseAbility(Vector2 touchPoint)
    {
        Vector2 way = BattleCommunicator.instance.GetPositionByX(touchPoint);

        if (BattleCommunicator.instance.CheckAnyAround(way))
        {
            Instantiate(barricade, way, Quaternion.identity);
            return true;
        }
        else
        {
            return false;
        }

    }
}
