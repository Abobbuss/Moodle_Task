using TMPro;
using UnityEngine;

public class SpawnerStatsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cubesSpawnedText;
    [SerializeField] private TextMeshProUGUI _cubesActiveText;
    [SerializeField] private TextMeshProUGUI _cubesTotalText;
    [SerializeField] private TextMeshProUGUI _bombsSpawnedText;
    [SerializeField] private TextMeshProUGUI _bombsActiveText;
    [SerializeField] private TextMeshProUGUI _bombsTotalText;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    private void Update()
    {
        _cubesSpawnedText.text = " количество созданых кубов: " + _cubeSpawner.GetCreatedCount();
        _cubesActiveText.text = "количество активных кубов: " + _cubeSpawner.GetActiveCount();
        _cubesTotalText.text = "количество заспавненых кубов: " + _cubeSpawner.GetTotalSpawned();
        _bombsSpawnedText.text = " количество созданных бомб: " + _bombSpawner.GetCreatedCount();
        _bombsActiveText.text = "количество активных бомб: " + _bombSpawner.GetActiveCount();
        _bombsTotalText.text = "количество заспавненых бомб: " + _bombSpawner.GetTotalSpawned();
    }
}
