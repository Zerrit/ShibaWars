using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSystem : MonoBehaviour
{
    public int Gold { get; private set; }
    public int Energy { get; private set; }

    private float lastIncomingTime = 0;
    private void Awake()
    {
        EventsManager.instance.OnGoldChange += IncreaseGold;
        //EventsManager.instance.OnEnergyChange += IncreaseEnergy;
    }


    public void Init(int startGold, int startEnergy)
    {
        Gold = startGold; 
        Energy = startEnergy;
    }

    public bool SpentGold(int cost)
    {
        if (Gold >= cost)
        {
            Gold -= cost;
            return true;
        }
        else return false;

    }
    public bool SpendEnergy(int cost)
    {
        if (Energy >= cost)
        {
            Energy -= cost;
            return true;
        }
        else return false;
    }

    public void IncreaseGold(int amount)
    {
        Gold += amount;
    }
    public void IncreaseEnergy(int amount)
    {
        Energy += amount;
    }

    private void PassiveIncoming()
    {
        if(Time.time > lastIncomingTime + 3.0f)
        {
            EventsManager.instance.StartChangeGoldEvent(35);
        }
    }
}
