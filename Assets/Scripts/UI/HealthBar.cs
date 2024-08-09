using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    public Slider slider;

    public void SetHealthBar(int currentHealth, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        healthText.text = string.Format("{0}/{1}", currentHealth, maxHealth);
    }
}
