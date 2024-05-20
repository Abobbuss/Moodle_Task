using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Renderer))]
public class ExplosionCube : MonoBehaviour, IClickable
{
    [SerializeField] private float _currentChanceSeparation = 100f;

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
        float explosionForce = 1000;
        float explosionRadius = 20;

        for (int i = 0; i < countChildren; i++)
        {
            ExplosionCube childCube = Instantiate(this, transform.position, Quaternion.identity);
            childCube.transform.localScale = transform.localScale / 2f;
            childCube.ChangeChanceSeparation(_currentChanceSeparation / 2f);
            childCube.ChangeColor();

            GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    private void ChangeChanceSeparation(float chanceSeparation) => _currentChanceSeparation = chanceSeparation;

    private void ChangeColor()
    {
        if (_renderer != null)
        {
            _renderer.material.color = new Color(
                Random.value, // Случайное значение для красного канала
                Random.value, // Случайное значение для зеленого канала
                Random.value  // Случайное значение для синего канала
            );
        }
        else
        {
            Debug.LogError("Renderer is not initialized. Cannot change color.");
        }
    }
}
