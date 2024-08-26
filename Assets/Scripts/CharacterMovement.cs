using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    public NavMeshAgent _agent;
    public Animator _anim;
    public VariableJoystick _variableJoystick;

    public Vector3 _joystickDir;
    public Vector3 _moveDir;

    public float _moveSpeed = 6f;
    public float _turnSmoothTime = 0.1f;

    float _turnSmoothVelocity;
    public bool isAttack = false;

    void LateUpdate()
    {
        if (Time.timeScale == 1)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (isAttack)
            {
                horizontal = 0f;
                vertical = 0f;
            }

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            Vector3 joyStickDirection = Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal;

            if (Application.isMobilePlatform && isAttack == false && _variableJoystick.Vertical != 0 && _variableJoystick.Horizontal != 0)
            {
                float targetAngleJoyStick = Mathf.Atan2(joyStickDirection.x, joyStickDirection.z) * Mathf.Rad2Deg;
                float angleJoyStick = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleJoyStick, ref _turnSmoothVelocity, _turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angleJoyStick, 0f);

                _joystickDir = Quaternion.Euler(0, targetAngleJoyStick, 0) * Vector3.forward;

                _anim.Play("RunForward");

                _agent.velocity = joyStickDirection * _moveSpeed * Time.fixedDeltaTime;
                _agent.SetDestination(joyStickDirection + _agent.transform.position);
            }

            else if (horizontal != 0 || vertical != 0)
            {
                if (direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    _moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

                    switch (PlayerPrefs.GetString("PlayableCharacter"))
                    {
                        case "Warrior":
                            _anim.Play("RunForward");
                            break;
                        case "Shooter":
                            _anim.Play("Shoot.RunForward");
                            break;
                        case "Wizard":
                            _anim.Play("RunForward");
                            break;
                    }

                    _agent.velocity = _moveDir * _moveSpeed * Time.fixedDeltaTime;
                    _agent.SetDestination(_moveDir + _agent.transform.position);
                }
            }

            else if (isAttack == false)
            {
                _agent.SetDestination(_agent.transform.position);

                switch (PlayerPrefs.GetString("PlayableCharacter"))
                {
                    case "Warrior":
                        _anim.Play("Idle");
                        break;
                    case "Shooter":
                        _anim.Play("Shoot.Idle");
                        break;
                    case "Wizard":
                        _anim.Play("Idle");
                        break;
                }
            }
        }
    }
}
