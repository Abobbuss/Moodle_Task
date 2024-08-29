using UnityEngine;

public class BombSpawner : BaseSpawner<Bomb>
{
    public void SubscribeToDestroyCube(Cube cube)
        => cube.Destroed += SpawnBomb;

    public void UnSubscribeToDestroyCube(Cube cube)
        => cube.Destroed -= SpawnBomb;

    private void SpawnBomb(Cube cube)
    {
        Bomb bomb = Pool.Get();
        bomb.transform.position = cube.transform.position;
    }

    protected override void OnGet(Bomb bomb)
    {
        bomb.Destroed += Release;
        bomb.gameObject.SetActive(true);
        bomb.StartFadeCoroutine();
    }

    protected override void Release(Bomb bomb)
    {
        Pool.Release(bomb);
        bomb.Destroed -= Release;
    }
}