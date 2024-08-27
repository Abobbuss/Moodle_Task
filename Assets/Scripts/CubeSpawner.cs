using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CubeSpawner : BaseSpawner<Cube>
{
    [SerializeField] private float _timeCreate;
    [SerializeField] private BombSpawner _bombSpawner;
    private Collider _zoneCollider;

    protected override void Awake()
    {
        base.Awake();
        _zoneCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(StartPool());
    }

    protected override void OnRelease(Cube cube)
    {
        _bombSpawner.UnSubscribeToDestroyCube(cube);
    }

    private IEnumerator StartPool()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeCreate);

            GetCube();
        }
    }

    private void GetCube()
    {
        _pool.Get();
    }

    protected override void OnGet(Cube cube)
    {
        _bombSpawner.SubscribeToDestroyCube(cube);
        cube.transform.position = GetCreatingPosition();
        cube.gameObject.SetActive(true);
        cube.Initialize(_pool);
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