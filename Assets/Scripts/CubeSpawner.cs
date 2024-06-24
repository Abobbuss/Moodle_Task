using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(BoxCollider))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _timeCreate;

    private Collider _zoneCollider;
    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _zoneCollider = GetComponent<BoxCollider>();

        _pool = new ObjectPool<Cube>(
                           createFunc: () => Create(),
                           actionOnGet: (obj) => obj.OnGet(_pool, GetCreatingPosition()),
                           actionOnRelease: (obj) => obj.OnRelease(),
                           actionOnDestroy: (obj) => Destroy(obj.gameObject)
                       );
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _timeCreate);
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private Cube Create() 
    {
        Vector3 position = GetCreatingPosition();

        return Instantiate(_cube, position, Quaternion.identity);
    }

    private Vector3 GetCreatingPosition()
    {
        Bounds bounds = _zoneCollider.bounds;
        Vector3 center = bounds.center;
        Vector3 size = bounds.size;

        Vector3 randomPosition = new Vector3(
            Random.Range(center.x - size.x / 2, center.x + size.x / 2),
            Random.Range(center.y - size.y / 2, center.y + size.y / 2),
            Random.Range(center.z - size.z / 2, center.z + size.z / 2)
        );

        return randomPosition;
    }
}
