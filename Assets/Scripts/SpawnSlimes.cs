using System.Collections.Generic;
using UnityEngine;

public class SpawnSlimes : MonoBehaviour
{
    public List<Transform> _spawnPoints;
    public GameObject _slimePrefab;
    private int _slimesLimit = 20;
    public int _score;

    void Start()
    {
        _spawnPoints = new List<Transform>(_spawnPoints);
        SpawnLimits();
        Spawn();
    }

    public void SpawnLimits()
    {
        if (_score >= 100)
        {
            _slimesLimit = 25;
            if (_score >= 200)
            {
                _slimesLimit = 30;
                if (_score >= 300)
                {
                    _slimesLimit = 35;
                    if (_score >= 400)
                    {
                        _slimesLimit = 40;
                        if (_score >= 500)
                        {
                            _slimesLimit = 50;
                        }
                    }
                }
            }
        }
    }

    public void Spawn()
    {
        for(int i = 0;i < _slimesLimit; i++)
        {
            var spawn = UnityEngine.Random.Range(0, _spawnPoints.Count);
            Instantiate(_slimePrefab, _spawnPoints[spawn].transform.position, Quaternion.identity);
        }
    }

    public void SpawnOnce()
    {
        var spawn = UnityEngine.Random.Range(0, _spawnPoints.Count);
        Instantiate(_slimePrefab, _spawnPoints[spawn].transform.position, Quaternion.identity);
    }

}
