using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public bool isUpgradable;

    public Player1Tower economic;
    public Image cooldownImage;
    public Button button;

    [HideInInspector]
    public UpgradePanelController upgradePanel;
    [HideInInspector]
    public Button upgradeButton;

    [Header("Данные для автозаполнения")]
    public Text price;
    public Text buttonName;
    public int cost;
    public int cooldown;

    public string firstPathText;
    public string firstPathFirstUpgradeText;
    public string firstPathSecondUpgradeText;

    public string secondPathText;
    public string secondPathFirstUpgradeText;
    public string secondPathSecondUpgradeText;



    [HideInInspector]
    public int buttonId;
    [HideInInspector]
    public bool isAbility;
    [HideInInspector]
    public bool onCooldown;

    private float timer;

    public int numberOfUses = 0;
    public int upgradePath;


    private void Start()
    {
        if (isUpgradable)
        {
            upgradeButton = transform.GetChild(0).GetComponent<Button>();
            SetUpgradeButtonData(firstPathText, secondPathText);
        }
    }

    private void OnDisable()
    {
        if (isUpgradable) upgradeButton.onClick.RemoveAllListeners();
        button.onClick.RemoveAllListeners();
    }


    public void Update()
    {
        CheckEccess();
        Cooldown();
    }

    public void SetUpgradeButtonData(string firstText, string secondText)
    {
        upgradeButton.onClick.AddListener(() => upgradePanel.ActivatePanel(firstText, secondText, isAbility, buttonId, this));
        upgradeButton.onClick.AddListener(() => upgradeButton.animator.SetTrigger("Close"));
    }

    public void InstallSelectedPath(int path)
    {
        upgradePath = path;
    }

    public void IncreaceNumberOfUses()
    {
        numberOfUses++;

        if(numberOfUses == 1)
        {
            upgradeButton.animator.SetTrigger("Open");
        }

        if(numberOfUses == 2)
        {
            if(upgradePath == 1)
            {
                SetUpgradeButtonData(firstPathFirstUpgradeText, firstPathSecondUpgradeText);
            }
            else if(upgradePath == 2)
            {
                SetUpgradeButtonData(secondPathFirstUpgradeText, secondPathSecondUpgradeText);
            }

            upgradeButton.animator.SetTrigger("Open");
        }
    }

    public void StartCooldown()
    {
        if(onCooldown) return;

        timer = cooldown;
        onCooldown = true;
    }

    private void Cooldown()
    {
        if (timer < 0) onCooldown = false;
        if (onCooldown) timer -= Time.deltaTime;

        cooldownImage.fillAmount = (onCooldown) ? (timer / cooldown) : 0;
    }

    private void CheckEccess()
    {
        if (isAbility) button.interactable = (economic.mana >= cost && !onCooldown) ? true : false;
        else button.interactable = (economic.gold >= cost && !onCooldown) ? true : false;
    }
}
