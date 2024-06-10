using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCountChildren = 2;
    [SerializeField] private int _maxCountChildren = 6;
    [SerializeField] private int _dividerLocalScaleChildrenCube = 2;
    [SerializeField] private int _dividerChanceSeparationChildrenCube = 2;

    public void CreateChildren(CubeSeparator parentCube, float parentChanceSeparation)
    {
        int countChildren = Random.Range(_minCountChildren, _maxCountChildren + 1);

        for (int i = 0; i < countChildren; i++)
        {
            CubeSeparator childCube = Instantiate(parentCube, parentCube.transform.position, Quaternion.identity);
            childCube.transform.localScale = parentCube.transform.localScale / _dividerLocalScaleChildrenCube;
            childCube.Init(parentChanceSeparation / _dividerChanceSeparationChildrenCube);
        }
    }
}
