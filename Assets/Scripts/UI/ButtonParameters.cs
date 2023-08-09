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
}
