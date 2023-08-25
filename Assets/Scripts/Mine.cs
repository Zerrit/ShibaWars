using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mine : MonoBehaviour, IDamageable
{
    [SerializeField] private Side side;

    private Side playerSide;

    public int maxHealth = 250;
    public float distance;
    public Transform healthBar;
    public GameObject heatlhBarlObject;
    public Button buildButton;
    public GameObject leftPlayerFlag;
    public GameObject rightPlayerFlag;


    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Transform SelfTransform { get; set; }
    public bool IsDefeated { get; set; }


    public void Initialize(Side playerSide)
    {
        this.playerSide = playerSide;
        MaxHealth = maxHealth;
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
        CurrentHealth = MaxHealth;
        healthBar.localScale = new Vector2(1, 1);
        heatlhBarlObject.SetActive(true);
        EventsManager.instance.TakeMine();
        BattleCommunicator.instance.AddBuilding(this, side);

        if (side == Side.left) leftPlayerFlag.SetActive(true);
        else if(side == Side.right) rightPlayerFlag.SetActive(true);
    }

    public void GetDamage(float damage)
    {
        if (IsDefeated != true)
        {
            Mathf.Clamp(CurrentHealth -= damage, 0, MaxHealth);
            healthBar.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

            if (CurrentHealth <= 0) DefeatSelf();
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
        heatlhBarlObject.SetActive(false);
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
    }
}
