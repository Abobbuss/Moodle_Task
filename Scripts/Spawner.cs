using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay = 0f;
    [SerializeField] private float _repetRate = 2.0f;
    [SerializeField] private Enemy _enemyPrefab;

    private List<Transform> _playerTargets = new List<Transform>();
    private const string _playerTag = "Player";

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(_playerTag);

        foreach (GameObject player in players)
        {
            _playerTargets.Add(player.transform);
        }

        InvokeRepeating(nameof(CreateEnemy), _delay, _repetRate);
    }

    private void CreateEnemy()
    {
        Transform randomPlayer = _playerTargets[Random.Range(0, _playerTargets.Count)];

        Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity).GetComponent<Enemy>();
        newEnemy.SetTarget(randomPlayer);
    }
}
