using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsComponent : MonoBehaviour
{
    public ParticleSystem AttackFX;


    public void SetFXPosition(Vector2 position)
    {
        AttackFX.transform.position = position;
    }

    public void PlayAttackFX()
    {

        AttackFX.Play();
    }
}
