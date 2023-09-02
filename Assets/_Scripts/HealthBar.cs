using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Transform _healtBar;
    [SerializeField]private Transform _health;
    [SerializeField]private SpriteRenderer _healthRenderer;

    private int _maxHealth;
    private int _currentHealth;


    public void Initialize(int maxHealth, Side side)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;

        if (side == Side.right)
        {
            _healthRenderer.color = Color.red;
            _healtBar.Rotate(new Vector2(0, 180), Space.World);
        }
    }

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }


    public void ReduceHealth(int value)
    {
        _currentHealth -= value;
        ChangeHealthBar();
    }
    private void ChangeHealthBar()
    {
        _health.localScale = new Vector2(Mathf.Clamp01((float)_currentHealth / _maxHealth), 1f);
    }


    public bool HasHealth()
    {
        if (_currentHealth > 0) return true;
        else return false;
    }
    public void ResetHealthBar()
    {
        _currentHealth = _maxHealth;
        _health.localScale = new Vector2(1, 1);
        ShowBar();
    }

    public void HideBar()
    {
        gameObject.SetActive(false);
    }
    public void ShowBar()
    {
        gameObject.SetActive(true);
    }
}
