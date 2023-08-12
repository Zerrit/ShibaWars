using UnityEngine;

public class BarricadeObject : MonoBehaviour, IDamageable
{
    public int maxHealt = 200;
    public int lifeTime = 8;
    private float spawnTime;
    public Transform HealthBar;
    public ParticleSystem spawnFX;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Transform SelfTransform { get; set; }
    public bool IsDead { get; set; }

    private void Awake()
    {
        MaxHealth = maxHealt;
        SelfTransform = transform;
    }

    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
        IsDead = false;
        spawnFX.Play();
        spawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > spawnTime + lifeTime)
        {
            KillSelf();
        }
    }

    public void GetDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthBar.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

        if (CurrentHealth <= 0) KillSelf();
    }

    public void KillSelf()
    {
        IsDead = true;
        Destroy(gameObject, 0.5f);
    }
}
