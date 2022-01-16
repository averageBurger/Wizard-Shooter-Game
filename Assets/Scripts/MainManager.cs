using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    GameObject player;
    [SerializeField] List<GameObject> enemyPrefabs;

    float spawnTime = 4;

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnTimer());
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Vector2 pos = GetSpawnPos(); // ABSTRACTION
        Instantiate(enemy, pos, transform.rotation);
    }

    Vector2 GetSpawnPos()
    {
        Vector2 spawn = new Vector2(Random.Range(-11, 11), Random.Range(-3, 3));
        Vector2 position = (Vector2)player.transform.position - spawn;
        if (position.x > -1 && position.x < 1)
        {
            return GetSpawnPos();
        }
        else if (position.y > -1 && position.y < 1)
        {
            return GetSpawnPos();
        }
        else
        {
            return spawn;
        }
    }

    IEnumerator SpawnTimer()
    {
        while (!player.GetComponent<PlayerController>().gameOver)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
