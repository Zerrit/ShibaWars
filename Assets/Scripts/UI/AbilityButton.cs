using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : ButtonController
{
    private bool isSelect = false;
    public ParticleSystem selectedFX;


    protected override void OnEnable()
    {
        base.OnEnable();
        EventsManager.instance.OnEnergyUpdate += CheckEccess;
        EventsManager.instance.OnAbilitySelect += SwitchSelectMode;
        EventsManager.instance.OnAbilityCast += ApplyAbility;
    }

    protected override void PressButton()
    {
        EventsManager.instance.SelectAbility(buttonId);
    }

    private void ApplyAbility(int id)
    {
        if (id != buttonId) return;

        SwitchSelectMode(id);
        StartCooldown();
        EventsManager.instance.ReduceEnergy(cost);
    }

    private void SwitchSelectMode(int buttonId)
    {
        if (isSelect)
        {
            selectedFX.Stop();
            isSelect = false;
        }
        else
        {
            if (this.buttonId == buttonId)
            {
                selectedFX.Play();
                isSelect = true;
            }
            else return;
        }
    }
}
