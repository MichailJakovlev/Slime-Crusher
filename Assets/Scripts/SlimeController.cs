using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public SlimeInfo _slimeInfo;
    public SpawnSlimes _spawn;

    public int _score = 0;
    public int _currentHealth;

    public void Start()
    {
        var _spawn = GetComponent<SpawnSlimes>();
        _currentHealth = _slimeInfo.health;
    }

    public void HitSlime(int hitAmount, Collider target)
    {
        if (_currentHealth - hitAmount <= 0)
        {
            
            _spawn.SpawnOnce();
            //.GetComponent<Animator>().Play("Damage_02");
            Destroy(target.gameObject);
            _score++;
        }

        else
        {
            _currentHealth = _currentHealth - hitAmount;
        }
    }


}
