using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public HealthBar characterHealth;
    [SerializeField] public int maxHealth;
    [SerializeField] public int damageTaken;
    [SerializeField] public int healTaken;
    [SerializeField] public float moveSpeed;

    int currentHealth;


    public void HealCharacter(int healAmount)
    {
        if (currentHealth + healAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + healAmount;
        }
        characterHealth.SetHealthBar(currentHealth, maxHealth);
    }

    public void HitCharacter(int hitAmount)
    {
        if (currentHealth - hitAmount < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth = currentHealth - hitAmount;
        }
        characterHealth.SetHealthBar(currentHealth, maxHealth);
    }

    void Awake()
    {
        characterMovement._moveSpeed = characterMovement._moveSpeed * moveSpeed;
        currentHealth = maxHealth;
        characterHealth.SetHealthBar(currentHealth, maxHealth);
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HealCharacter(healTaken);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitCharacter(damageTaken);
        }
    }
}
