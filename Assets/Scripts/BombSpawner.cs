using UnityEngine;

public class BombSpawner : BaseSpawner<Bomb>
{
    public void SubscribeToDestroyCube(Cube cube)
        => cube.Destroed += SpawnBomb;

    public void UnSubscribeToDestroyCube(Cube cube)
        => cube.Destroed -= SpawnBomb;

    private void SpawnBomb(Vector3 position)
    {
        Bomb bomb = _pool.Get();
        bomb.transform.position = position;
    }

    protected override void OnGet(Bomb bomb)
    {
        bomb.Initialize(_pool);
        bomb.gameObject.SetActive(true);
        bomb.StartFadeCoroutine();
    }
}