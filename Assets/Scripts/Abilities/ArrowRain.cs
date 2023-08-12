using UnityEngine;

[CreateAssetMenu(fileName = "ArrowRain", menuName = "Ability/ArrowRainAbility")]
public class ArrowRain : Ability
{
    public ArrowRainObject arrowRain;

    [Header("Дополнительные параметры")]
    public int damage;

    public override bool UseAbility(Vector2 touchPoint)
    {
        Vector2 way = BattleCommunicator.instance.GetPositionByX(touchPoint);
        Instantiate(arrowRain, way, Quaternion.identity);

        return true;
    }
}