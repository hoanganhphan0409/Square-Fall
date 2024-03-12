using System.Collections;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField] private float badSquareInterval = 1f;
    [SerializeField] private float goodSquareInterval = 3f;
    [SerializeField] private ObjectPooling objectPooling;
    
    void Start()
    {
        Observer.LoseGame += OnLoseGame;
        Observer.ReplayGame += StartSpawn;
        Observer.StartGame += StartSpawn;
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnSquare(badSquareInterval, true)); 
        StartCoroutine(SpawnSquare(goodSquareInterval, false));
    }

    private IEnumerator SpawnSquare(float interval, bool isSpawnBadSquare)
    {
        yield return new WaitForSeconds(interval);
        if (isSpawnBadSquare)
        {
            var newSquare = objectPooling.GetPooledBadSquare();
            newSquare.StartFall();
        }
        else
        {
            var newSquare = objectPooling.GetPooledGoodSquare();
            newSquare.StartFall();
        }
        StartCoroutine(SpawnSquare(interval, isSpawnBadSquare));
    }

    void OnLoseGame()
    {
        StopAllCoroutines();
        objectPooling.OnLoseGame();
    }

    private void OnDestroy()
    {
        Observer.LoseGame -= OnLoseGame;
        Observer.ReplayGame -= StartSpawn;
        Observer.StartGame -= StartSpawn;
    }
}