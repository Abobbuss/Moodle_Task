using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Renderer))]
public class ExplosionCube : MonoBehaviour, IClickable
{
    [SerializeField] private float _currentChanceSeparation = 100f;
    [SerializeField] private int _explosionForce = 20;
    [SerializeField] private int _explosionRadius = 5;

    private Renderer _renderer;
    private int _minCountChildren = 2;
    private int _maxCountChildren = 6;

    private void OnEnable() => _renderer = GetComponent<Renderer>();

    public void OnClick()
    {
        if(Random.Range(0, 100) <= _currentChanceSeparation)
            CreateChildren();

        Destroy(gameObject);
    }

    private void CreateChildren()
    {
        int countChildren = Random.Range(_minCountChildren, _maxCountChildren);

        for (int i = 0; i < countChildren; i++)
        {
            ExplosionCube childCube = Instantiate(this, transform.position, Quaternion.identity);
            childCube.transform.localScale = transform.localScale / 2f;

            childCube.ChangeChanceSeparation(_currentChanceSeparation / 2f);
            childCube.ChangeColor();
            childCube.ExplosionForce();
        }
    }

    private void ChangeChanceSeparation(float chanceSeparation) => _currentChanceSeparation = chanceSeparation;

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
            Debug.LogError("Renderer is not initialized. Cannot change color.");
        }
    }

    private void ExplosionForce() => GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
}
