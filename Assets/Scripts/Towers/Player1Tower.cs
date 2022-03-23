using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Tower : MainTower
{
    [Header("UI")]
    public Text goldScore;
    public Text manaScore;


    [Header("OtherParameters")]
    private int passiveIncomingTime = 0;


    private void Start()
    {
        buttonManager = GameObject.Find("UI").GetComponent<InterfaceManager>();
    }

    public void Update()
    {
        PassiveIncoming();
    }

    private void PassiveIncoming()
    {
        goldScore.text = gold.ToString();
        manaScore.text = mana.ToString();

        if (Time.time > passiveIncomingTime)
        {
            passiveIncomingTime += 1;
            gold++;
            mana++;
        }
    }
}
