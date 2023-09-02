
public class UnitButton : ButtonController
{
    public override void Initialize()
    {
        base.Initialize();
        EventsManager.instance.OnGoldUpdate += CheckEccess;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        EventsManager.instance.OnGoldUpdate -= CheckEccess;
    }

    protected override void PressButton()
    {
        StartCooldown();

        EventsManager.instance.CreateUnut(buttonId);
        EventsManager.instance.ReduceGold(cost);
    }
}
