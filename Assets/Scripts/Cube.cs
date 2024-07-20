using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;

    private Renderer _renderer;
    private ObjectPool<Cube> _pool;

    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;
    private bool _hasCollided = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void HandlePlatformCollision()
    {
        if (_hasCollided) 
            return;

        _hasCollided = true;
        ChangeColor();
        StartCoroutine(DestroyAfterRandomTime());
    }

    public void Initialize(ObjectPool<Cube> pool)
    {
        _pool = pool;
        _hasCollided = false;
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
        _renderer.material.color = _defaultColor;
    }

    private void ChangeColor()
    {
        if (_renderer != null)
        {
            _renderer.material.color = new Color(
                Random.value,
                Random.value,
                Random.value
            );
        }
        else
        {
            Debug.LogError("Renderer отсутсвует");
        }
    }

    private IEnumerator DestroyAfterRandomTime()
    {
        float randomTime = Random.Range(_minLifeTime, _maxLifeTime);

        yield return new WaitForSeconds(randomTime);

        _pool.Release(this);
    }
}
