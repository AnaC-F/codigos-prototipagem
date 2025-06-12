using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int _currentHealth;
    private bool _isDead = false;

    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        _currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = _currentHealth;
        }

        UpdateHealthText();
    }

    public void TakeDamage(int amount)
    {
        if (_isDead) return;

        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = _currentHealth;
        }

        UpdateHealthText();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            float percent = (float)_currentHealth / maxHealth * 100f;
            int rounded = Mathf.FloorToInt(percent / 10) * 10;
            healthText.text = rounded + "%";
        }
    }

    void Die()
    {
        _isDead = true;
        Invoke(nameof(ReloadScene), 1f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}