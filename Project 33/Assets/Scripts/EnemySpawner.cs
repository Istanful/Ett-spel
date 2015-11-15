using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public float minTimeBetweenSpawns = 5.0f;
    public float maxTimeBetweenSpawns = 15.0f;
    [SerializeField]
    public List<SpawnableEnemy> enemies;

    bool spawnReady = true;

    void Start()
    {
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
            Instantiate(enemies[enemyIndex].enemy, transform.position, transform.rotation);

        yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
        spawnReady = true;
    }

    [System.Serializable]
    public class SpawnableEnemy
    {
        public GameObject enemy;
        public int rarity = 5;
    }
}
