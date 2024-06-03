using UnityEngine;

[RequireComponent (typeof(Renderer))]
[RequireComponent(typeof(CubeSpawner))]
[RequireComponent(typeof(ExplosionCube))]
public class CubeSeparator : MonoBehaviour, IClickable
{
    [SerializeField] private float _currentChanceSeparation = 100f;
    
    private CubeSpawner _cubeSpawner;
    private Renderer _renderer;
    private ExplosionCube _explosionCube;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
        _renderer = GetComponent<Renderer>();
        _explosionCube = GetComponent<ExplosionCube>();
    }

    public void OnClick()
    {
        if (Random.Range(0, 100) <= _currentChanceSeparation)
            _cubeSpawner.CreateChildren(this, _currentChanceSeparation);
        else
            _explosionCube.Explosion();

        Destroy(gameObject);
    }

    public void ChangeChanceSeparation(float chanceSeparation) => _currentChanceSeparation = chanceSeparation;

    public void ChangeColor()
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
}
