using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public bool isLimitReached;


    [Header("Данные для автозаполнения")]
    public int buttonId;
    public int cost;
    public int cooldown;
    public TextMeshProUGUI costText;
    public Button button;

    public Image cooldownImage;

    private bool onCooldown;
    private float timer;

    protected virtual void OnEnable()
    {
        button.onClick.AddListener(PressButton);
    }


    public void Update()
    {
        Cooldown();
    }

    public void StartCooldown()
    {
        if(onCooldown) return;

        timer = cooldown;
        onCooldown = true;
        button.interactable = false;
    }

    private void Cooldown()
    {
        if (!onCooldown) return;

        timer -= Time.deltaTime;
        if (timer <= 0) onCooldown = false;
        cooldownImage.fillAmount = (onCooldown) ? (timer / cooldown) : 0;
    }

    protected void CheckEccess(int value)
    {
        button.interactable = (value >= cost && !onCooldown && !isLimitReached) ? true : false;
    }

    protected virtual void PressButton()
    {

    }
}
