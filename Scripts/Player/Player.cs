using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _target1;
    [SerializeField] private Transform _target2;
    [SerializeField] private float _speed = 5f;

    private Transform _currentTarget;

    private void Start()
    {
        _currentTarget = _target1;
    }

    private void Update()
    {
        MoveToTarget(_currentTarget);

        if (Vector3.Distance(transform.position, _currentTarget.position) < 0.25f)
            SwitchTarget();
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void SwitchTarget()
    {
        if (_currentTarget == _target1)
            _currentTarget = _target2;
        else
            _currentTarget = _target1;
    }
}
