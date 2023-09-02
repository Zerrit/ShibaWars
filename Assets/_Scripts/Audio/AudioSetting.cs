using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _effectsToggle;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;

    public void Initialize()
    {
        _musicToggle.onValueChanged.AddListener((val) => AudioManager.instance.ToggleMusic(val));
        _effectsToggle.onValueChanged.AddListener((val) => AudioManager.instance.ToggleEffects(val));
        _musicSlider.onValueChanged.AddListener((val) => AudioManager.instance.ChangeMusicVolume(val));
        _effectsSlider.onValueChanged.AddListener((val) => AudioManager.instance.ChangeEffectsVolume(val));
    }

    private void OnDisable()
    {
        _musicToggle.onValueChanged.RemoveAllListeners();
        _effectsToggle.onValueChanged.RemoveAllListeners();
        _musicSlider.onValueChanged.RemoveAllListeners();
        _effectsSlider.onValueChanged.RemoveAllListeners();
    }
}
