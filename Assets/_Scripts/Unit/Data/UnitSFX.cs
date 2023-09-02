using UnityEngine;

public class UnitSFX : ScriptableObject
{
    public AudioClip spawnSound;
    public AudioClip attackSound;
    public AudioClip deathSound;

    public void PlaySound(AudioClip sound)
    {
        AudioManager.instance.PlayEffect(sound);
    }
}
