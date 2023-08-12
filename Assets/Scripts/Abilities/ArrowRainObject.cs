using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRainObject : MonoBehaviour
{
    public int damage;
    private float lastDamageTime = 0;
    List<IDamageable> allTargets = new List<IDamageable>();

    private void Update()
    {
        DamageAllTargers();
        Destroy(gameObject, 4f);
    }


    private void DamageAllTargers()
    {
        if(Time.time >= lastDamageTime + 0.25f)
        {
            allTargets = BattleCommunicator.instance.CheckUnitsAround((Vector2)transform.position);

            foreach(IDamageable target in allTargets)
            {
                target.GetDamage(5);
                lastDamageTime = Time.time;
            }
        }
    }

}
