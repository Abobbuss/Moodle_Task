using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        _cubesSpawnedText.text = " количество заспавненых кубов: " + _cubeSpawner.GetCreatedCount();
        _cubesActiveText.text = "количество активных кубов: " + _cubeSpawner.GetActiveCount();
        _cubesTotalText.text = "тотал кубов: " + _cubeSpawner.GetTotalCubesSpawned();
        _bombsSpawnedText.text = " количество заспавненых бомб: " + _cubeSpawner.GetCreatedCount();
        _bombsActiveText.text = "количество активных бомб: " + _cubeSpawner.GetActiveCount();
        _bombsTotalText.text = "тотал бомб: " + _cubeSpawner.GetTotalCubesSpawned();
    }
}
