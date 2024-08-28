using TMPro;
using UnityEngine;


// Поэтому пока оставлю с двумя
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
        _cubesSpawnedText.text = " Количество созданных: " + _cubeSpawner.GetCreatedCount();
        _cubesActiveText.text = "Количество активных: " + _cubeSpawner.GetActiveCount();
        _cubesTotalText.text = "Количество заспавненных: " + _cubeSpawner.GetTotalSpawned();
        _bombsSpawnedText.text = " Количество созданных: " + _bombSpawner.GetCreatedCount();
        _bombsActiveText.text = "Количество активных: " + _bombSpawner.GetActiveCount();
        _bombsTotalText.text = "Количество заспавненных: " + _bombSpawner.GetTotalSpawned();
    }
}

// Я не могу вставить данный класс как игровой объект, тк он не поддерживает дженерик, в чате никто не помог(
// Поэтому не совсем понимаю как использовать один справнер типа BaseSpawner если он там дженерик ожидает
/*public class SpawnerStatsDisplay<T> where T : BaseSpawner<T>
{
    [SerializeField] private TextMeshProUGUI _spawnedText;
    [SerializeField] private TextMeshProUGUI _activeText;
    [SerializeField] private TextMeshProUGUI _totalText;
    [SerializeField] private BaseSpawner<T> _spawner;

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
}*/
