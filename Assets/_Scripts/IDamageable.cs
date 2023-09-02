using UnityEngine;

public interface IDamageable
{
    Transform SelfTransform { get; set; }
    bool IsDefeated { get; set; }

    public void GetDamage(int damage);

    public void DefeatSelf();
}