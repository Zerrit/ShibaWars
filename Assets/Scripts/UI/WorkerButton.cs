
using Unity.VisualScripting;

public class WorkerButton : ButtonController
{
    public bool isLimitReached;

    protected override void OnEnable()
    {
        base.OnEnable();
        EventsManager.instance.OnGoldUpdate += CheckEccess;
    }
    protected override void OnDisable()
    {
        EventsManager.instance.OnGoldUpdate -= CheckEccess;
    }

    protected override void PressButton()
    {
        StartCooldown();
        EventsManager.instance.AddWorker();
        EventsManager.instance.ReduceGold(cost);
    }

    protected override void CheckEccess(int value)
    {
        button.interactable = (value >= cost && !onCooldown && !isLimitReached) ? true : false;
    }
}
