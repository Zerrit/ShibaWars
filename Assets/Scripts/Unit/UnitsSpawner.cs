using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsSpawner : MonoBehaviour
{
    public MainTower tower;
    public MiniMap miniMap;

    [SerializeField]
    public UnitStruct[] unitsStruct = new UnitStruct[4];


    [Header("Unit Worker")]
    public ShibaSlave worker;
    public ButtonController workerButton;
    public ButtonParameters workerParameters;

    private void Start()
    {
        FillButtonData();
    }

    public void CreateUnit(int unitNumber)
    {
        tower.PayGold(unitsStruct[unitNumber].unitParameters.cost);
        unitsStruct[unitNumber].unitButton.StartCooldown();

        Entity unit = Instantiate(unitsStruct[unitNumber].unit, tower.spawnPosition, transform.rotation, miniMap.unitFolder);

        miniMap.AddNewIcon(unit);
        unitsStruct[unitNumber].unitButton.IncreaceNumberOfUses();

        unit.upgradePath = unitsStruct[unitNumber].upgradePath;
        unit.subUpgradePath = unitsStruct[unitNumber].subUpgradePath;
    }


    public void CreateWorker()
    {
        tower.PayGold(workerParameters.cost);
        workerButton.StartCooldown();
            
        ShibaSlave shiba = Instantiate(worker, tower.spawnPosition, transform.rotation);
        shiba.CastlePos = transform.position;
        shiba.mainTowerGold = tower;
    }


    private void FillButtonData()
    {
        workerButton = tower.buttonManager.workerButton;

        for (int i = 0; i < 4; i++)
        {
            unitsStruct[i].unitButton = tower.buttonManager.unitButtons[i];
        }

        workerButton.button.image.sprite = workerParameters.buttonIcone;
        workerButton.price.text = workerParameters.cost.ToString();
        workerButton.cooldown = workerParameters.cooldown;
        workerButton.cost = workerParameters.cost;

        workerButton.button.onClick.AddListener(() => CreateWorker());

        foreach (UnitStruct unit in unitsStruct)
        {
            unit.unitButton.button.image.sprite = unit.unitParameters.buttonIcone;
            unit.unitButton.price.text = unit.unitParameters.cost.ToString();
            unit.unitButton.cooldown = unit.unitParameters.cooldown;
            unit.unitButton.cost = unit.unitParameters.cost;

            unit.unitButton.firstPathText = unit.unitParameters.firstPath;
            unit.unitButton.firstPathFirstUpgradeText = unit.unitParameters.firstPathFirstUpgrade;
            unit.unitButton.firstPathSecondUpgradeText = unit.unitParameters.firstPathSecondUpgrade;


            unit.unitButton.secondPathText = unit.unitParameters.secondPath;
            unit.unitButton.secondPathFirstUpgradeText = unit.unitParameters.secondPathFirstUpgrade;
            unit.unitButton.secondPathSecondUpgradeText = unit.unitParameters.secondPathSecondUpgrade;

            unit.unitButton.button.onClick.AddListener(() => CreateUnit(unit.unitButton.buttonId));
        }
    }
}
