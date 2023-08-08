using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{ 
    public PlayerTower economic;
    public Image cooldownImage;
    public Button button;

    [Header("Данные для автозаполнения")]
    public TextMeshProUGUI cost;
    public int price;
    public int cooldown;

    public bool isAbility;
    public bool onCooldown;

    public float timer;

    public void Update()
    {
        //CheckEccess();
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

/*    private void CheckEccess()
    {
        if (isAbility) button.interactable = (economic.mana >= cost && !onCooldown) ? true : false;
        else button.interactable = (economic.gold >= cost && !onCooldown) ? true : false;
    }*/
}
