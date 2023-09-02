using UnityEngine;

public class Barricade : Ability, IDamageable
{
    public int maxHealth = 200;
    public int lifeTime = 6;
    private float spawnTime;

    [SerializeField] private HealthBar _healthBar;
    public ParticleSystem spawnFX;

    private Vector2 abilityPlace;

    public bool IsDefeated { get; set; }
    public Transform SelfTransform { get; set; }


    private void OnEnable()
    {
        _healthBar.ResetHealthBar();
        IsDefeated = false;
        spawnFX.Play();
        spawnTime = Time.time;
    }
    private void Update()
    {
        if (Time.time > spawnTime + lifeTime)
        {
            DefeatSelf();
        }
    }


    public override void Initialize(Side side)
    {
        this.side = side;
        _healthBar.Initialize(maxHealth, side);
        SelfTransform = transform;
    }

    public override bool SelectTarget(Vector2 touchPoint)
    {
        abilityPlace = BattleCommunicator.instance.GetPositionByX(touchPoint);

        if (!BattleCommunicator.instance.CheckAnyAround(abilityPlace)) return true;
        else return false;
    }

    public override void UseAbility()
    {
        SelfTransform.position = abilityPlace;
        BattleCommunicator.instance.AddBarricade(this, side);
    }


    public void GetDamage(int damage)
    {
        if (IsDefeated == false)
        {
            _healthBar.ReduceHealth(damage);
            if (!_healthBar.HasHealth()) DefeatSelf();
        }
    }
    public void DefeatSelf()
    {
        IsDefeated = true;
        BattleCommunicator.instance.RemoveBarricade(this, side);
        gameObject.SetActive(false); 
    }
}
