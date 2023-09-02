using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _currentPanel;

    [SerializeField] private GameObject _mainMenu;
    [SerializeField]  private GameObject _settings;


    private void Start()
    {
        DontDestroyOnLoad(this);
        _currentPanel = _mainMenu;
    }

    public void OpenSettings()
    {
        _settings.SetActive(true);
        _currentPanel?.SetActive(false);
        _currentPanel = _settings;
    }

    public void OpenMainMenu()
    {
        _mainMenu.SetActive(true);
        _currentPanel?.SetActive(false);
        _currentPanel = _mainMenu;
    }
}
