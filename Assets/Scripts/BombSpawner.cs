using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(BoxCollider))]
public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;

    private ObjectPool<Bomb> _pool;
    private int _totalBombSpawned = 0;

    private void Awake()
    {
        _pool = new ObjectPool<Bomb>(
                           createFunc: Create,
                           actionOnGet: (obj) => OnGet(obj),
                           actionOnRelease: (obj) => obj.OnRelease(),
                           actionOnDestroy: (obj) => Destroy(obj.gameObject)
                       );
    }

    private void OnEnable()
    {
        Cube.Destroing += SpawnBomb;
    }

    private void OnDisable()
    {
        Cube.Destroing -= SpawnBomb;
    }

    public int GetTotalCubesSpawned() 
        => _totalBombSpawned;
    public int GetCreatedCount() 
        => _pool.CountAll;
    public int GetActiveCount() 
        => _pool.CountActive;

    private void SpawnBomb(Vector3 position)
    {
        Bomb bomb = _pool.Get();
        bomb.transform.position = position;
        bomb.gameObject.SetActive(true);
    }

    private Bomb Create()
    {
        _totalBombSpawned++;

        return Instantiate(_bomb);
    }

    private void OnGet(Bomb bomb)
    {
        bomb.Initialize(_pool);
    }
}
