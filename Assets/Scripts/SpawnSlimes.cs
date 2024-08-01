using System.Collections.Generic;
using UnityEngine;

public class SpawnSlimes : MonoBehaviour
{
    public List<Transform> _spawnPoints;
    public GameObject _slimePrefab;
    private int _slimesLimit = 20;

    void Start()
    {
        _spawnPoints = new List<Transform>(_spawnPoints);
        Spawn();
    }

    public void Spawn()
    {
        for(int i = 0;i < _slimesLimit; i++)
        {
            var spawn = UnityEngine.Random.Range(0, _spawnPoints.Count);
            Instantiate(_slimePrefab, _spawnPoints[spawn].transform.position, Quaternion.identity);
        }
    }
}
