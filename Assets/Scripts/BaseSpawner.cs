using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;

    protected ObjectPool<T> _pool;
    protected int _totalSpawned = 0;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: Create,
            actionOnGet: OnGet,
            actionOnRelease: obj => obj.gameObject.SetActive(false),
            actionOnDestroy: obj => Destroy(obj.gameObject)
        );
    }

    public int GetTotalSpawned() 
        => _totalSpawned;

    public int GetCreatedCount() 
        => _pool.CountAll;

    public int GetActiveCount() 
        => _pool.CountActive;

    protected abstract void OnGet(T obj);
    protected virtual void OnRelease(T item) { }

    protected virtual T Create()
    {
        _totalSpawned++;

        return Instantiate(_prefab);
    }
}