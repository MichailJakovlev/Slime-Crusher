using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] public int _damageValue;
    [SerializeField] public float _animationTime;
    [SerializeField] public float _cooldownTime;

    public Animator _characterAnim;
    public CharacterMovement _moveScript;

    public bool _cooldown = false;

    public SmallSlime _smallSlime;

    public GameObject _shooter;
    public Transform arrowSpawnPoint;
    public GameObject _arrow;
    public float arrowSpeed = 10;

    void LateUpdate()
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
                StartCoroutine(Attack());
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

    IEnumerator Attack()
    {
        float startTime = Time.time;
        _moveScript.isAttack = true;
        _smallSlime._isDamageTaking = true;

        while (Time.time < startTime + _animationTime)
        {
            _characterAnim.Play("Shooter.BowShot");
            yield return null;
        }

        _smallSlime._isDamageTaking = false;
        _moveScript.isAttack = false;
    }
}
