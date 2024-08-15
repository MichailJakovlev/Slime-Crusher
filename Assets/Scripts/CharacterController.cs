using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public HealthBar characterHealth;
    public UIController uiController;
    public CharacterMovement _moveScript;
    public Animator _characterAnim;

    [SerializeField] public int maxHealth;
    [SerializeField] public int damageTaken;
    [SerializeField] public int healTaken;
    [SerializeField] public float moveSpeed;

    public int currentHealth;
    public float attackTime;

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
        StartCoroutine(Attack());
    }

    void Awake()
    {
        characterMovement._moveSpeed = characterMovement._moveSpeed * moveSpeed;
        currentHealth = maxHealth;
        characterHealth.SetHealthBar(currentHealth, maxHealth);
    }
    void LateUpdate()
    {
        if (!uiController.pauseMenu.isActiveAndEnabled && !uiController.gameOverMenu.isActiveAndEnabled)
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

    IEnumerator Attack()
    {
        float startTime = Time.time;
        _moveScript.isAttack = true;

        while (Time.time < startTime + attackTime)
        {
            _characterAnim.Play("GetHit");

            yield return null;
        }
        _moveScript.isAttack = false;
    }
}
