using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnSlimes : MonoBehaviour
{
    public List<Transform> _spawnPoints;
    public List<GameObject> _slimesTypes;

    public SlimeController _attackScript;
    public TextMeshProUGUI _scoreText;

    private int _slimesTypesLimit = 1;
    private int _slimesLimit = 20;

    void Start()
    {
        var _attackScript = GetComponent<SlimeController>();
        _slimesTypes = new List<GameObject>(_slimesTypes);
        _spawnPoints = new List<Transform>(_spawnPoints);
        Spawn();
    }

    public void Update()
    {
        if (_attackScript._score >= 100)
        {
            _slimesTypesLimit = 2;
            _slimesLimit = 25;
            if (_attackScript._score >= 200)
            {
                _slimesTypesLimit = 3;
                _slimesLimit = 30;
                if (_attackScript._score >= 300)
                {
                    _slimesTypesLimit = 4;
                    _slimesLimit = 35;
                    if (_attackScript._score >= 400)
                    {
                        _slimesTypesLimit = 5;
                        _slimesLimit = 40;
                        if (_attackScript._score >= 500)
                        {
                            _slimesTypesLimit = 6;
                            _slimesLimit = 50;
                        }
                    }
                }
            }
        }
        _scoreText.text = _attackScript._score.ToString();
    }

    public void Spawn()
    {
        for(int i = 0;i < _slimesLimit; i++)
        {
            var spawn = Random.Range(0, _spawnPoints.Count);
            Instantiate(_slimesTypes[0], _spawnPoints[spawn].transform.position, Quaternion.identity);
        }
    }

    public void SpawnOnce()
    {
        var spawn = Random.Range(0, _spawnPoints.Count);
        var slime = Random.Range(0, _slimesTypesLimit);
        Instantiate(_slimesTypes[slime], _spawnPoints[spawn].transform.position, Quaternion.identity);
    }

}
