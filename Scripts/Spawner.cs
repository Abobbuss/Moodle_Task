using UnityEngine;


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

        Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.Euler(0f, _rotateY, 0f)).GetComponent<Enemy>();
    }

    private float GetRotateToEnemy()
    {
        return Random.Range(0, 180f);
    }
}
