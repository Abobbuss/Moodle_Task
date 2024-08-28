using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

[RequireComponent(typeof(Color))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 15f;
    
    private float _fadeDuration;
    private Renderer _renderer;
    private Material _material;
    private Color _startColor = Color.black;
    private Color _endColor;

    public event UnityAction<Bomb> Destroed;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0f);
    }

    public void StartFadeCoroutine()
    {
        StartCoroutine(FadeAndExplode());
        _material.color = _startColor;
    }

    private IEnumerator FadeAndExplode()
    {
        float maxFadeDuration = 2f;
        float minFadeDuration = 5f;
        float elapsedTime = 0f;
        _fadeDuration = Random.Range(maxFadeDuration, minFadeDuration);

        while (elapsedTime < _fadeDuration)
        {
            _material.color = Color.Lerp(_startColor, _endColor, elapsedTime / _fadeDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _material.color = _endColor;
        Explode();
        Destroed?.Invoke(this);
    }

    private void Explode()
    {
        float force = 500f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(force, transform.position, _explosionRadius);
        }
    }
}
