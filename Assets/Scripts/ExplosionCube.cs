using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosionCube : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 10f;
    [SerializeField] private float _baseExplosionRadius = 1f;

    public void Explosion()
    {
        var (explosionForce, explosionRadius) = CountExplosionCharacteristics(transform);

        Vector3 explosionPosition = transform.position;
        Collider[] explosionObjects = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider obj in explosionObjects)
        {
            if (obj.TryGetComponent(out Rigidbody rb))
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }

    private (float force, float radius) CountExplosionCharacteristics(Transform transform)
    {
        float size = transform.localScale.magnitude;
        float force = _baseExplosionForce / size;
        float radius = _baseExplosionRadius / size;

        return (force, radius);
    }
}
