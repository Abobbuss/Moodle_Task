using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;

    protected ObjectPool<T> Pool;
    protected int TotalSpawned = 0;

    public event UnityAction ChangedCount;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: Create,
            actionOnGet: OnGet,
            actionOnRelease: obj => obj.gameObject.SetActive(false),
            actionOnDestroy: obj => Destroy(obj.gameObject)
        );
    }

    public int GetTotalSpawned()
        => TotalSpawned;

    public int GetCreatedCount() 
        => Pool.CountAll;

    public int GetActiveCount() 
        => Pool.CountActive;

    protected abstract void OnGet(T obj);
    protected virtual void Release(T item) 
    {
        ChangedCount?.Invoke();
    }

    private T Create()
    {
        TotalSpawned++;
        ChangedCount?.Invoke();

        return Instantiate(Prefab);
    }
}