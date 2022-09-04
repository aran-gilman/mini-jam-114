using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
    [Serializable]
    public class SpawnRule
    {
        public float time;
        public Spawner spawnPoint;
        public GameObject prefab;
        public int number;
    }

    public List<SpawnRule> spawnRules = new List<SpawnRule>();
    public float spawnCooldown = 1.0f;

    private float timeInWave;
    private float maxWaveTime;

    private void Start()
    {
        timeInWave = 0.0f;
        foreach (var rule in spawnRules)
        {
            float estimatedSpawnEnd = rule.time + rule.number * spawnCooldown + 5;
            if (estimatedSpawnEnd > maxWaveTime)
            {
                maxWaveTime = estimatedSpawnEnd;
            }
        }
    }

    private void Update()
    {
        foreach (SpawnRule rule in spawnRules)
        {
            if (rule.time >= timeInWave && rule.time < timeInWave + Time.deltaTime)
            {
                for (int i = 0; i < rule.number; i++)
                {
                    rule.spawnPoint.QueueSpawn(rule.prefab);
                }
            }
        }
        timeInWave += Time.deltaTime;

        if (timeInWave > maxWaveTime)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
