using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosionCube : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 10f;
    [SerializeField] private float _baseExplosionRadius = 1f;

    private float _localSize;

    private void Start()
    {
        _localSize = transform.localScale.magnitude;
    }

    public void GenerateExplosion()
    {
        float explosionForce = CountExplosionForce();
        float explosionRadius = CountExplosionRadius();

        Vector3 explosionPosition = transform.position;
        Collider[] explosionObjects = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider obj in explosionObjects)
        {
            if (obj.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }

    private float CountExplosionRadius() => _baseExplosionRadius / _localSize;

    private float CountExplosionForce() => _baseExplosionForce / _localSize;
}
