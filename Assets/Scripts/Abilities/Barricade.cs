using UnityEngine;

public class Barricade : Ability, IDamageable
{
    public int maxHealth = 200;
    public int lifeTime = 6;
    private float spawnTime;

    public Transform HealthBar;
    public ParticleSystem spawnFX;

    private Vector2 abilityPlace;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public bool IsDefeated { get; set; }
    public Transform SelfTransform { get; set; }


    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
        HealthBar.localScale = new Vector2(1, 1);
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
        MaxHealth = maxHealth;
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


    public void GetDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthBar.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

        if (CurrentHealth <= 0) DefeatSelf();
    }
    public void DefeatSelf()
    {
        IsDefeated = true;
        BattleCommunicator.instance.RemoveBarricade(this, side);
        gameObject.SetActive(false); 
    }
}
