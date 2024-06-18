using UnityEngine;

[RequireComponent (typeof(Renderer))]
[RequireComponent(typeof(CubeSpawner))]
[RequireComponent(typeof(ExplosionCube))]
public class CubeSeparator : MonoBehaviour
{
    [SerializeField] private float _currentChanceSeparation = 100f;
    
    private CubeSpawner _cubeSpawner;
    private Renderer _renderer;
    private ExplosionCube _explosionCube;
    private float _maxChanceSeparation = 100f;
    private float _minChanceSeparation = 0f;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
        _renderer = GetComponent<Renderer>();
        _explosionCube = GetComponent<ExplosionCube>();
    }

    public void OnClick()
    {
        
    }

    public void Init(float chanceSeparation)
    {
        ChangeChanceSeparation(chanceSeparation);
        ChangeColor();
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
            Debug.LogError("Renderer отсутсвует");
        }
    }
}
