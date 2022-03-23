using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvents : MonoBehaviour
{
    public PlayerSide playerSide;

    public delegate void Upgrade(int playerSide, int id, int variant); //���������� id - ���������� ����� �����/�����������. ���������� Variant ���������� ����� �������� �������� 1 ��� 2;

    public static event Upgrade OnUnitUpgrade;
    public static event Upgrade OnAbilityUpgrade;


    public void UpgradeUnitFirstPathEvent(int id)
    {
        OnUnitUpgrade?.Invoke((int)playerSide, id, 1);
    }

    public void UpgradeUnitSecondPathEvent(int id)
    {
        OnUnitUpgrade?.Invoke((int)playerSide, id, 2);
    }



    public void UpgradeAbilityFirstPathEvent(int id)
    {
        OnAbilityUpgrade?.Invoke((int)playerSide, id, 1);
    }

    public void UpgradeAbilitySecondPathEvent(int id)
    {
        OnAbilityUpgrade?.Invoke((int)playerSide, id, 2);
    }

}
