using UnityEngine;

public interface IDamageable
{
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    Transform SelfTransform { get; set; }
    bool IsDefeated { get; set; }

    public void GetDamage(float damage);

    public void DefeatSelf();
}