using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _asteroidPrefab = new GameObject[6];
    [SerializeField]
    private GameObject _coinPrefab;

    private Vector2 _secondsBetweenSpawnMinMax = new Vector2(0.05f, 1f);
    private Vector2 _spawnSizleMinMax = new Vector2(0.3f,1.8f);
    private float _spawnAngleMax = 15;
    private float _nextSpawnTime;
    private Vector2 _screenHalfSizeWorldUnits;
    private float _coinSpawnTime;


    void Start()
    {
        _screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }


    void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            AsteroidSpawn();

        }
        if(Time.time > _coinSpawnTime)
        {
            CoinSpawn();
        }
    }
    private void CoinSpawn()
    {

        _coinSpawnTime = Time.time + 1;
        Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x), _screenHalfSizeWorldUnits.y);
        Instantiate(_coinPrefab, spawnPosition, Quaternion.Euler(Vector3.forward));
    }
    private void AsteroidSpawn()
    {
        float secondsBetweenSpawn = Mathf.Lerp(_secondsBetweenSpawnMinMax.y, _secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
        _nextSpawnTime = Time.time + secondsBetweenSpawn;

        float spawnAngle = Random.Range(-_spawnAngleMax, _spawnAngleMax);
        float spawnSize = Random.Range(_spawnSizleMinMax.x, _spawnSizleMinMax.y);
        Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x), _screenHalfSizeWorldUnits.y + spawnSize);
        GameObject newAsteroid = (GameObject)Instantiate(_asteroidPrefab[Random.Range(0, _asteroidPrefab.Length)], spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
        newAsteroid.transform.localScale = Vector2.one * spawnSize;
    }
}
