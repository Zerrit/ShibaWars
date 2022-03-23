using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    public enum PlayerSide
    {
        leftPlayer,
        rightPlayer
    }

    public PlayerSide playerSide;

    public InterfaceManager buttonManager;

    public int gold;
    public int mana;

    public Vector2 spawnPosition;

    public  void PayGold(int price)
    {
        if (gold >= price) gold -= price;
    }
    public  void PayMana(int price)
    {
        if (mana >= price) mana -= price;
    }
}
