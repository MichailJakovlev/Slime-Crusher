using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] public int _maxWarriorHealth;
    [SerializeField] public int _maxShooterHealth;
    [SerializeField] public int _maxWizardHealth;
    [SerializeField] public int _maxHountrHealth;
    
    public GameObject _playableCharacter;
    public Animator _characterAnim;
    public CharacterMovement _moveScript;
    public HealthBar _healthBar;

    public int _currentHealth;
    public int _maxHealth;
    public float _animationTime;

    void Start()
    {
        _playableCharacter = GameObject.FindWithTag("Player");
        _characterAnim = GameObject.FindWithTag("PlayerAnimLayer").GetComponent<Animator>();
        _moveScript = GameObject.FindWithTag("Player").GetComponent<CharacterMovement>();

        switch (PlayerPrefs.GetString("PlayableCharacter"))
        {
            case "Warrior":
                _currentHealth = _maxWarriorHealth;
                _maxHealth = _maxWarriorHealth;
            break;
            case "Shooter":
                _currentHealth = _maxShooterHealth;
                _maxHealth = _maxShooterHealth;
            break;
            case "Wizard":
                _currentHealth = _maxWizardHealth;
                _maxHealth = _maxWizardHealth;
            break;
            case "Hounter":
                _currentHealth = _maxHountrHealth;
                _maxHealth = _maxHountrHealth;
            break;
        }
        _healthBar.SetHealthBar(_currentHealth, _maxHealth);
    }

    public void GetHit(int hitAmount)
    {
        if (_currentHealth - hitAmount <= 0)
        {
            _currentHealth = 0;
        }
        else
        {
            _currentHealth = _currentHealth - hitAmount;
        }

        _healthBar.SetHealthBar(_currentHealth, _maxHealth);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Heal")
        {
            Destroy(other.gameObject);
            _currentHealth += _maxHealth / 100 * 25;
            _healthBar.SetHealthBar(_currentHealth, _maxHealth);
        }
    }
}
