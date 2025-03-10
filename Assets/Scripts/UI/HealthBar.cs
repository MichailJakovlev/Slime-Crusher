using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    public Slider slider;
    private void Start()
    {
        slider.enabled = false;
    }

    public void SetHealthBar(int currentHealth, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        healthText.text = string.Format("{0}/{1}", currentHealth, maxHealth);
    }
}
