using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	[SerializeField] private AudioSource _musicSource, _effectsSource; 

	void Start ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		} 
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void PlayEffect (AudioClip clip)
	{
		_effectsSource.PlayOneShot(clip);
	}
	public void PlayMusic(AudioClip clip)
	{
		_musicSource.PlayOneShot(clip);
	}



    public void ChangeMusicVolume(float value)
	{
		_musicSource.volume = value;
	}
    public void ChangeEffectsVolume(float value)
    {
        _effectsSource.volume = value;
    }
	public void ToggleMusic(bool value)
	{
		_musicSource.mute = value;
	}
    public void ToggleEffects(bool value)
    {
        _effectsSource.mute = value;
    }
}
