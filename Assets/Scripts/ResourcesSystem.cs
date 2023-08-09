using UnityEngine;

public class ResourcesSystem : MonoBehaviour
{
    public int startGold, startEnergy;

    public int Gold { get; private set; }
    public int Energy { get; private set; }

    private float lastIncomingTime = 0;
    private void Awake()
    {
        EventsManager.instance.OnGoldIncrease += IncreaseGold;
        EventsManager.instance.OnEnergyIncrease += IncreaseEnergy;
        EventsManager.instance.OnGoldReduce += SpendGold;
        EventsManager.instance.OnEnergyReduce += SpendEnergy;
    }

    private void Update()
    {
        PassiveIncoming();
    }

    public void Init()
    {
        Gold = startGold; 
        Energy = startEnergy;
        EventsManager.instance.UpdateGold(Gold);
    }

    public void SpendGold(int cost)
    {
        Gold -= cost;
        EventsManager.instance.UpdateGold(Gold);
    }
    public void SpendEnergy(int cost)
    {
        Energy -= cost;
        EventsManager.instance.UpdateEnergy(Energy);
    }

    public void IncreaseGold(int amount)
    {
        Gold += amount;
        EventsManager.instance.UpdateGold(Gold);
    }
    public void IncreaseEnergy(int amount)
    {
        Energy += amount;
        EventsManager.instance.UpdateEnergy(Energy);
    }

    private void PassiveIncoming()
    {
        if(Time.time >= lastIncomingTime + 1.0f)
        {
            EventsManager.instance.IncreaseGold(10);
            lastIncomingTime = Time.time;
        }
    }
}
