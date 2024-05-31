using UnityEngine;

[RequireComponent (typeof(ExplosionForceApplier))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCountChildren = 2;
    [SerializeField] private int _maxCountChildren = 6;
    [SerializeField] private int _dividerLocalScaleChildrenCube = 2;
    [SerializeField] private int _dividerChanceSeparationChildrenCube = 2;

    private ExplosionForceApplier _explosionForceApplier;

    private void Awake() => _explosionForceApplier = GetComponent<ExplosionForceApplier>();

    public void CreateChildren(ExplosionCube parentCube, float parentChanceSeparation)
    {
        int countChildren = Random.Range(_minCountChildren, _maxCountChildren);

        for (int i = 0; i < countChildren; i++)
        {
            ExplosionCube childCube = Instantiate(parentCube, parentCube.transform.position, Quaternion.identity);
            childCube.transform.localScale = parentCube.transform.localScale / _dividerLocalScaleChildrenCube;
            childCube.ChangeChanceSeparation(parentChanceSeparation / _dividerChanceSeparationChildrenCube);
            childCube.ChangeColor();

            _explosionForceApplier.ApplyExplosionForce(childCube);
        }
    }
}
