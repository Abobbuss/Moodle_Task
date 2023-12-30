using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay = 0f;
    [SerializeField] private float _repetRate = 2.0f;
    [SerializeField] private GameObject _enemyPrefab;

    private float _rotateY;

    private void Start()
    {
        InvokeRepeating(nameof(CreateEnemy), _delay, _repetRate);
    }

    private void CreateEnemy()
    {
        _rotateY = GetRotateToEnemy();

        GameObject newEnemyObject = Instantiate(_enemyPrefab, transform.position, Quaternion.Euler(0f, _rotateY, 0f));
    }

    private float GetRotateToEnemy()
    {
        return Random.Range(0, 180f);
    }
}

