using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

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

    protected override void Release(Cube cube)
    {
        Pool.Release(cube);
        _bombSpawner.UnSubscribeToDestroyCube(cube);
        UnSubscribeToCubeSpawn(cube);
    }

    private void SubscribeToCubeSpawn(Cube cube)
    {
        cube.Destroed += Release;
    }

    private void UnSubscribeToCubeSpawn(Cube cube)
    {
        cube.Destroed -= Release;
    }

    private IEnumerator StartPool()
    {
        var waitTime = new WaitForSeconds(_timeCreate);

        while (true)
        {
            yield return waitTime;

            GetCube();
        }
    }

    private void GetCube()
    {
        Pool.Get();
    }

    protected override void OnGet(Cube cube)
    {
        _bombSpawner.SubscribeToDestroyCube(cube);
        SubscribeToCubeSpawn(cube);
        cube.transform.position = GetCreatingPosition();
        cube.gameObject.SetActive(true);
        cube.Initialize();
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