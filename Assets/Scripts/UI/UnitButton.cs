using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitButton : ButtonController
{
    protected override void PressButton()
    {
        StartCooldown();

        EventsManager.instance.CreateUnut(buttonId);
        EventsManager.instance.ReduceGold(cost);
    }

    protected override IEnumerator SubscribeEvent()
    {
        yield return new WaitUntil(() => EventsManager.instance != null);

        EventsManager.instance.OnGoldUpdate += CheckEccess;
    }
}
