
public class WorkerButton : ButtonController
{
    protected override void OnEnable()
    {
        base.OnEnable();
        EventsManager.instance.OnGoldUpdate += CheckEccess;
    }

    protected override void PressButton()
    {
        StartCooldown();
        EventsManager.instance.AddWorker();
        EventsManager.instance.ReduceGold(cost);
    }
}
