using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSide
{
    leftPlayer,
    rightPlayer
}

public class InterfaceManager : MonoBehaviour
{
    public PlayerSide playerSide;

    public UpgradePanelController upgradePanelController;
    public UIEvents events;


    public ButtonController[] unitButtons;
    public ButtonController[] abilityButtons;
    public ButtonController workerButton;

    private void Start()
    {
        events = GetComponent<UIEvents>();

        events.playerSide = playerSide;
        upgradePanelController.events = events;

        for (int i = 0; i < unitButtons.Length; i++)
        {
            unitButtons[i].buttonId = i;
            unitButtons[i].isAbility = false;
            unitButtons[i].upgradePanel = upgradePanelController;
        }

        for (int i = 0; i < abilityButtons.Length; i++)
        {
            abilityButtons[i].buttonId = i;
            abilityButtons[i].isAbility = true;
            abilityButtons[i].upgradePanel = upgradePanelController;
        }
    }
}
