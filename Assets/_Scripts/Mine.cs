using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mine : MonoBehaviour, IDamageable
{
    [SerializeField] private Side side;
    [SerializeField] private HealthBar _healthBar;

    private Side playerSide;

    public int maxHealth = 250;
    public float distance;
    public Button buildButton;
    public GameObject leftPlayerFlag;
    public GameObject rightPlayerFlag;


    public Transform SelfTransform { get; set; }
    public bool IsDefeated { get; set; }


    public void Initialize(Side playerSide)
    {
        this.playerSide = playerSide;
        _healthBar.Initialize(maxHealth, side);
        SelfTransform = transform;
        buildButton.onClick.AddListener(BuildMine);

        switch (side)
        {
            case Side.neutral:
                IsDefeated = true;
                break;

            case Side.left:
                BuildMine();
                break;

            case Side.right:
                BuildMine();
                break;
        }
    }

    private void Update()
    {
        if (IsDefeated) TrackInfluence();
    }

    private void TrackInfluence()
    {
        if(BattleCommunicator.instance.CheckInfluenceChange(SelfTransform.position.x, ref side))
        {
            if (side == playerSide) ShowButton();
            else HideButton();
        }
    }

    private void BuildMine()
    {
        HideButton();
        IsDefeated = false;
        _healthBar.ResetHealthBar();
        _healthBar.ShowBar();
        EventsManager.instance.TakeMine();
        BattleCommunicator.instance.AddBuilding(this, side);

        if (side == Side.left) leftPlayerFlag.SetActive(true);
        else if(side == Side.right) rightPlayerFlag.SetActive(true);
    }

    public void GetDamage(int damage)
    {
        if (IsDefeated != true)
        {
            _healthBar.ReduceHealth(damage);

            if (!_healthBar.HasHealth()) DefeatSelf();
        }
    }

    public void DefeatSelf()
    {
        IsDefeated = true;
        EventsManager.instance.LostMine();
        BattleCommunicator.instance.RevomeBuilding(this, side);

        ChangeInfluence();

        leftPlayerFlag.SetActive(false);
        rightPlayerFlag.SetActive(false);
        _healthBar.HideBar();
    }

    private void ChangeInfluence()
    {
        if (side == Side.left) side = Side.right;
        else side = Side.left;
    }
    private void ShowButton()
    {
        buildButton.gameObject.SetActive(true);
        buildButton.onClick.AddListener(BuildMine);
    }
    private void HideButton()
    {
        buildButton.gameObject.SetActive(false);
        buildButton.onClick.RemoveAllListeners();
    }
}
