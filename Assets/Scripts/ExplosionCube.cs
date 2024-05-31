using UnityEngine;

[RequireComponent (typeof(Renderer))]
[RequireComponent(typeof(CubeSpawner))]
public class ExplosionCube : MonoBehaviour, IClickable
{
    [SerializeField] private float _currentChanceSeparation = 100f;
    
    private CubeSpawner _cubeSpawner;
    private Renderer _renderer;

    private void OnEnable() => _renderer = GetComponent<Renderer>();

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();

        if (_cubeSpawner == null)
            Debug.LogError("CubeSpawner отсутсвует");
    }

    public void OnClick()
    {
        if (Random.Range(0, 100) <= _currentChanceSeparation)
            _cubeSpawner.CreateChildren(this, _currentChanceSeparation);

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
