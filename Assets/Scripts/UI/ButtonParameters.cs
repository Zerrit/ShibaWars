using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameters", menuName = "Button/ButtonParameters")]
public class ButtonParameters : ScriptableObject
{
    [Header("Description")]
    public string buttonName;
    public Sprite buttonIcone;

    [Header("Parameters")]
    public int cooldown;
    public int cost;

    [Header("Upgrade")]
    public string firstPath;

    public string firstPathFirstUpgrade;
    public string firstPathSecondUpgrade;

    //------------------------------//

    public string secondPath;

    public string secondPathFirstUpgrade;
    public string secondPathSecondUpgrade;
}
