using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 15f;
    
    private float _fadeDuration;
    private Renderer _renderer;
    private ObjectPool<Bomb> _pool;
    private Material _material;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    public void Initialize(ObjectPool<Bomb> pool)
    {
        _pool = pool;
        StartCoroutine(FadeAndExplode());
    }

    private IEnumerator FadeAndExplode()
    {
        float maxFadeDuration = 2f;
        float minFadeDuration = 5f;
        float elapsedTime = 0f;
        _fadeDuration = Random.Range(maxFadeDuration, minFadeDuration);
        Color startColor = _material.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < _fadeDuration)
        {
            _material.color = Color.Lerp(startColor, endColor, elapsedTime / _fadeDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _material.color = endColor;
        Explode();
        _pool.Release(this);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(500f, transform.position, _explosionRadius);
        }
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
        _material.color = new Color(0f, 0f, 0f, 1f);
    }
}
