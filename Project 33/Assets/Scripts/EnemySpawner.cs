using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    public float randomTimeBetweenSpawns = 1;
    [SerializeField]
    public List<SpawnableEnemy> enemies;

    bool spawnReady = true;

    void Start()
    {
        instance = this;

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0));
        newPosition.y = 23;
        newPosition.z = 0;
        transform.position = newPosition;
    }

    void Update()
    {
        if (spawnReady)
        {
            StartCoroutine(SpawnEnemy());
            spawnReady = false;
        }
    }

    IEnumerator SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Count);
        if (Random.Range(0, enemies[enemyIndex].rarity) == 0)
        {
            Instantiate(enemies[enemyIndex].enemy, transform.position, transform.rotation);
            yield return new WaitForSeconds(Random.Range(0, randomTimeBetweenSpawns) + enemies[enemyIndex].delayAfterSpawn);
        }
        else
        {
            Debug.Log("Spawning of " + enemies[enemyIndex].enemy.name + " failed. Redoing spawn.");
            yield return new WaitForSeconds(0.01f);
        }
        spawnReady = true;
    }

    [System.Serializable]
    public class SpawnableEnemy
    {
        public GameObject enemy;
        public int rarity = 0;
        public float delayAfterSpawn = 0;
    }
}
