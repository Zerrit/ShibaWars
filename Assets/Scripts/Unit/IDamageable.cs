using UnityEngine;

public interface IDamageable
{
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    Transform SelfTransform { get; set; }
    bool IsDead { get; set; }

    public void GetDamage(float damage);

    public void KillSelf();
}