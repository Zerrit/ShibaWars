using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mine : MonoBehaviour, IDamageable
{
    public bool isDefeated;

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

    public PlayerSide side;



    private void Start()
    {
        IsDefeated = isDefeated;
        MaxHealth = maxHealth;
        SelfTransform = transform;
        buildButton.onClick.AddListener(BuildMine);

        if (IsDefeated)
        {
            buildButton.gameObject.SetActive(true);
        }
        else
        {
            buildButton.gameObject.SetActive(false);

        }


        if (!IsDefeated)
        {
            CurrentHealth = MaxHealth;
            EventsManager.instance.TakeMine();
        }
    }

    private void Update()
    {
        if (isDefeated) ChangeInfluence();
    }

    private void ChangeInfluence()
    {
        PlayerSide currentInfluence = BattleCommunicator.instance.DefineInfluence(SelfTransform.position.x);
        if (side != currentInfluence)
        {
            side = currentInfluence;
        }
    }

    private void BuildMine()
    {
        HideButton();
        IsDefeated = false;
        CurrentHealth = MaxHealth;
        healthBar.localScale = new Vector2(1, 1);
        EventsManager.instance.TakeMine();

        if (side == PlayerSide.leftPlayer) leftPlayerFlag.SetActive(true);
        else rightPlayerFlag.SetActive(true);
    }

    private void Conquest()
    {

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
        leftPlayerFlag.SetActive(false);
        rightPlayerFlag.SetActive(false);

        EventsManager.instance.LostMine();

        if (side == GameBootstrap.instance.playerSide) ShowButton();

    }

    private void InstallFlag()
    {
        if (side == PlayerSide.leftPlayer) leftPlayerFlag.SetActive(true);
        if (side == PlayerSide.rightPlayer) rightPlayerFlag.SetActive(true);
    }

    private void ShowButton()
    {
        buildButton.gameObject.SetActive(true);
    }

    private void HideButton()
    {
        buildButton.gameObject.SetActive(false);
    }
}
