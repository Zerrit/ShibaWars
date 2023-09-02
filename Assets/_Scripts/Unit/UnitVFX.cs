using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitVFX : MonoBehaviour
{
    public ParticleSystem hitFX;

    public void PlayHitFX()
    {
        hitFX.Play();
    }
    public void PlayOnPlace(Vector2 FXpos, ParticleSystem FX)
    {
        FX.transform.position = FXpos;
        FX.Play();
    }
}
