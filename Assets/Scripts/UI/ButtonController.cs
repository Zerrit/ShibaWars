using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [Header("Данные для автозаполнения")]
    public int buttonId;
    public int cost;
    public int cooldown;
    public bool isAbility;
    public TextMeshProUGUI costText;
    public Button button;

    public Image cooldownImage;

    private bool onCooldown;
    private float timer;

    private void Awake()
    {
        button.onClick.AddListener(PressButton);

        if (isAbility) EventsManager.instance.OnEnergyUpdate += CheckEccess;
        else EventsManager.instance.OnGoldUpdate += CheckEccess;
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
    }

    private void Cooldown()
    {
        if (timer < 0) onCooldown = false;
        if (onCooldown) timer -= Time.deltaTime;

        cooldownImage.fillAmount = (onCooldown) ? (timer / cooldown) : 0;
    }

    private void CheckEccess(int value)
    {
        button.interactable = (value >= cost && !onCooldown) ? true : false;
    }

    private void PressButton()
    {
        StartCooldown();

        if (isAbility) EventsManager.instance.CastAbility(buttonId);
        else EventsManager.instance.CreateUnut(buttonId);

        EventsManager.instance.ReduceGold(cost);
    }
}
