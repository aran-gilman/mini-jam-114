using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [Serializable]
    public class SpawnRule
    {
        public float time;
        public SlimeSpawner spawnPoint;
        public GameObject prefab;
        public int number;
    }

    public List<SpawnRule> spawnRules = new List<SpawnRule>();
    public float spawnCooldown = 1.0f;

    private float timeInWave;
    private int waveNumber;

    private float maxWaveTime;

    private void Start()
    {
        foreach (var rule in spawnRules)
        {
            float estimatedSpawnEnd = rule.time + rule.number * spawnCooldown;
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
            timeInWave = 0.0f;
            waveNumber++;
        }
    }
}
