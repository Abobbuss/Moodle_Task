using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            transform.Translate(_speed * Time.deltaTime * direction);
        }

        if (Vector3.Distance(transform.position, _target.position) < 0.25f)
            Destroy();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}