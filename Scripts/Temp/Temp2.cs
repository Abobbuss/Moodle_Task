using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _shootingInterval;

    private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        bool isWork = enabled;

        WaitForSeconds waitInterval = new WaitForSeconds(_shootingInterval);

        while (isWork)
        {
            Vector3 _vector3direction = (_objectToShoot.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_bulletPrefab, transform.position + _vector3direction, Quaternion.identity);

            newBullet.transform.up = _vector3direction;
            newBullet.velocity = _vector3direction * _bulletSpeed;

            yield return waitInterval;
        }
    }
}