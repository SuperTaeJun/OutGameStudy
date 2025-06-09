using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.FPS.AI;
public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public Transform[] SpawnPos;

    float timer;
    float spawneTime = 3f;

    private List<GameObject> enemies;

    const int MaxCount = 10;
    void Start()
    {
        enemies = new List<GameObject>();

        timer = spawneTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = spawneTime;

            int enemyCount = GameObject.FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;
            if (enemyCount >= MaxCount)
            {
                return;
            }

            var randomIndex = Random.Range(0, SpawnPos.Length);
            Instantiate(EnemyPrefab, SpawnPos[randomIndex].position, Quaternion.identity);
        }
    }
}
