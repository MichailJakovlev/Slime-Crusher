using System.Collections;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] public int _damageValue;
    [SerializeField] public float _animationTime;
    [SerializeField] public float _cooldownTime;

    public Animator _characterAnim;
    public CharacterMovement _moveScript;
    public CharacterBoosts _characterBoosts;
    public CharacterHealth _characterHealth;
    public SmallSlime _smallSlime;

    public Transform arrowSpawnPoint;
    public GameObject _shooter;
    public GameObject _arrow;

    public bool _cooldown = false;
    public float arrowSpeed = 10;

    public AudioManager _audioManager;

    public VariableJoystick _joystickAttack;

    public GameObject _attackButtonObject;
    public GameObject _attackJoystickObject;

    void Start()
    {
        _attackButtonObject.SetActive(true);
        _attackJoystickObject.SetActive(false);
    }

    void LateUpdate()
    {
        Vector3 joyStickDirection = Vector3.forward * _joystickAttack.Vertical + Vector3.right * _joystickAttack.Horizontal;
        if (Application.isMobilePlatform)
        {
            if (_cooldown == false && _joystickAttack.Vertical != 0 && _joystickAttack.Horizontal != 0)
            {
                float targetAngleJoyStick = Mathf.Atan2(joyStickDirection.x, joyStickDirection.z) * Mathf.Rad2Deg;
                _shooter.transform.rotation = Quaternion.Euler(0, targetAngleJoyStick, 0);

                var arrow = Instantiate(_arrow, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
                arrow.transform.Rotate(90, 0, 0);
                arrow.GetComponent<Rigidbody>().velocity = arrowSpawnPoint.forward * arrowSpeed;

                StartCoroutine(CooldownTimer());

                _characterAnim.Play("SpellCast");
                _characterAnim.Play("Idle");
                _moveScript.isAttack = true;
                _moveScript.isWizardCasting = true;
                _audioManager.FireSound();
            }
            if (_joystickAttack.Vertical == 0 && _joystickAttack.Horizontal == 0)
            {
                _moveScript.isWizardCasting = false;
                _moveScript.isAttack = false;
            }
        }
        else if (!Application.isMobilePlatform)
        {
            if (Input.GetMouseButton(0) && _cooldown == false)
            {
                Vector2 center = new Vector2(0.5f, 0.5f);
                Vector2 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);
                var angle = Mathf.Atan2(mousePosition.x - center.x, mousePosition.y - center.y) * Mathf.Rad2Deg;
                _shooter.transform.rotation = Quaternion.Euler(0, angle, 0);

                var arrow = Instantiate(_arrow, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
                arrow.transform.Rotate(90, 0, 0);
                arrow.GetComponent<Rigidbody>().velocity = arrowSpawnPoint.forward * arrowSpeed;

                StartCoroutine(CooldownTimer());

                _characterAnim.Play("SpellCast");
                _characterAnim.Play("Idle");
                _moveScript.isAttack = true;
                _moveScript.isWizardCasting = true;
                _audioManager.FireSound();
            }
            else if (Input.GetMouseButton(0) == false)
            {
                _moveScript.isWizardCasting = false;
                _moveScript.isAttack = false;
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Heal")
        {
            _characterHealth.GetHeal(other);
            _audioManager.TakeBoostSound();
        }

        if (other.gameObject.tag == "Speed")
        {
            _characterBoosts.SpeedBoost(other);
            _audioManager.TakeBoostSound();
        }

        if (other.gameObject.tag == "Damage")
        {
            _characterBoosts.DamageBoost(other);
            _audioManager.TakeBoostSound();
        }
    }

    IEnumerator CooldownTimer()
    {
        float startTime = Time.time;
        _cooldown = true;

        while (Time.time < startTime + _cooldownTime)
        {
            yield return null;
        }

        _cooldown = false;
    }
}
