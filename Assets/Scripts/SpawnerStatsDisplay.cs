using System.Data;
using TMPro;
using UnityEngine;

public class SpawnerStatsDisplay<TSpawner, TSpawnedObject> : MonoBehaviour
    where TSpawner : BaseSpawner<TSpawnedObject>
    where TSpawnedObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _spawnedText;
    [SerializeField] private TextMeshProUGUI _activeText;
    [SerializeField] private TextMeshProUGUI _totalText;
    [SerializeField] private TSpawner _spawner;

    private void OnEnable()
    {
        _spawner.ChangedCount += UpdateStats;
    }

    private void OnDisable()
    {
        _spawner.ChangedCount -= UpdateStats;
    }

    public void UpdateStats()
    {
        _spawnedText.text = "Количество созданных: " + _spawner.GetCreatedCount();
        _activeText.text = "Количество активных: " + _spawner.GetActiveCount();
        _totalText.text = "Количество заспавненных: " + _spawner.GetTotalSpawned();
    }
}
