using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnSlimes : MonoBehaviour
{
    public List<Transform> _spawnPoints;
    public List<GameObject> _slimesTypes;
    public TextMeshProUGUI _scoreText;

    private int _slimesTypesLimit = 1;
    private int _slimesLimit = 20;

    public int _score = 0;

    void Start()
    {
        _slimesTypes = new List<GameObject>(_slimesTypes);
        _spawnPoints = new List<Transform>(_spawnPoints);

        SpawnByLimit(0,_slimesLimit);
    }

    public void SpawnByLimit(int _startSpawningValue, int limit)
    {
        for (int i = _startSpawningValue; i < limit; i++)
        {
            var spawn = Random.Range(0, _spawnPoints.Count);
            Instantiate(_slimesTypes[0], _spawnPoints[spawn].transform.position, Quaternion.identity);
        }
    }

    public void Spawn()
    {
        switch(_score)
        {
            case 75:
                _slimesTypesLimit = 2;
                _slimesLimit = 25;
                SpawnByLimit(20, _slimesLimit);
                break;
            case 100:
                _slimesTypesLimit = 3;
                _slimesLimit = 30;
                SpawnByLimit(25, _slimesLimit);
                break;
            case 150:
                _slimesTypesLimit = 4;
                _slimesLimit = 35;
                SpawnByLimit(30, _slimesLimit);
                break;
            case 200:
                _slimesTypesLimit = 5;
                _slimesLimit = 40;
                SpawnByLimit(35, _slimesLimit);
                break;
        }

        var spawn = Random.Range(0, _spawnPoints.Count);

        if (_score > 200)
        {
            var luck = Random.Range(0, 10);

            if(luck == 0)
            {
                Instantiate(_slimesTypes[5], _spawnPoints[spawn].transform.position, Quaternion.identity);
            }

            else
            {
                var slime = Random.Range(0, _slimesTypesLimit);
                Instantiate(_slimesTypes[slime], _spawnPoints[spawn].transform.position, Quaternion.identity);
            }
        }

        else
        {
            var slime = Random.Range(0, _slimesTypesLimit);
            Instantiate(_slimesTypes[slime], _spawnPoints[spawn].transform.position, Quaternion.identity);
        }

        _score++;
        _scoreText.text = _score.ToString();
    }
}
