
public class UnitButton : ButtonController
{
    protected override void OnEnable()
    {
        base.OnEnable();
        EventsManager.instance.OnGoldUpdate += CheckEccess;
    }

    protected override void PressButton()
    {
        StartCooldown();

        EventsManager.instance.CreateUnut(buttonId);
        EventsManager.instance.ReduceGold(cost);
    }
}
