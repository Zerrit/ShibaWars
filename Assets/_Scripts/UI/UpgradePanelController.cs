using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelController : MonoBehaviour
{
    /*public InterfaceManager UIManager;
    public UIEvents events;

    public Text firstPathText;
    public Text secondPathText;

    public Button firstPathButton;
    public Button secondPathButton;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void ActivatePanel(string firstText, string secondText, bool isAbility, int number, ButtonController button)
    {
        Debug.Log("Панель обновлена");
        firstPathText.text = firstText;
        secondPathText.text = secondText;

        if (isAbility)
        {
            firstPathButton.onClick.AddListener(() => events.UpgradeAbilityFirstPathEvent(number));
            firstPathButton.onClick.AddListener(() => button.InstallSelectedPath(1));
            firstPathButton.onClick.AddListener(() => ClosePanel());

            secondPathButton.onClick.AddListener(() => events.UpgradeAbilitySecondPathEvent(number));
            secondPathButton.onClick.AddListener(() => button.InstallSelectedPath(2));
            secondPathButton.onClick.AddListener(() => ClosePanel());
        }
        else
        {
            firstPathButton.onClick.AddListener(() => events.UpgradeUnitFirstPathEvent(number));
            firstPathButton.onClick.AddListener(() => button.InstallSelectedPath(1));
            firstPathButton.onClick.AddListener(() => ClosePanel());

            secondPathButton.onClick.AddListener(() => events.UpgradeUnitSecondPathEvent(number));
            secondPathButton.onClick.AddListener(() => button.InstallSelectedPath(2));
            secondPathButton.onClick.AddListener(() => ClosePanel());
        }

        anim.SetBool("OnView", true);
    }


    public void ClosePanel()
    {
        anim.SetBool("OnView", false);
        firstPathButton.onClick.RemoveAllListeners();
        secondPathButton.onClick.RemoveAllListeners();
    }*/
}
