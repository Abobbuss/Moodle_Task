using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class ExplosionForceApplier : MonoBehaviour
{
    [SerializeField] private int _explosionForce = 20;
    [SerializeField] private int _explosionRadius = 5;

    public void ApplyExplosionForce(ExplosionCube cube)
    {
        Rigidbody rb = cube.GetComponent<Rigidbody>();

        if (rb != null)
            rb.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        else
            Debug.LogError("нету риджидбоди");
    }
}
