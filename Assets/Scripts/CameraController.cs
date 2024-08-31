using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothTime;

    private Transform target;
    private Vector3 _offset;
    private Vector3 _currentVelocity = Vector3.zero;

    public GameObject _warrior;
    public GameObject _shooter;
    public GameObject _wizard;
    public GameObject _hounter;

    private void Start()
    {
        switch (PlayerPrefs.GetString("PlayableCharacter"))
        {
            case "Warrior":
                target = _warrior.transform;
                break;
            case "Shooter":
                target = _shooter.transform;
                break;
            case "Wizard":
                target = _wizard.transform;
                break;
        }

        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
