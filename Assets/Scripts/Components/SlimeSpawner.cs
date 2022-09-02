using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public Direction slimeMovementDirection;

    public void QueueSpawn(GameObject prefab)
    {
        spawnQueue.Enqueue(prefab);
    }

    private float spawnCooldown = 0.0f;

    private Queue<GameObject> spawnQueue = new Queue<GameObject>();

    private EnemySpawnController enemySpawnController;

    private void Start()
    {
        enemySpawnController = GetComponentInParent<EnemySpawnController>();
    }

    private void Update()
    {
        if (spawnCooldown > 0.0f)
        {
            spawnCooldown -= Time.deltaTime;
        }
        else if (spawnQueue.Count > 0)
        {
            Spawn(spawnQueue.Dequeue());
            spawnCooldown = enemySpawnController.spawnCooldown;
        }
    }

    private void Spawn(GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = transform.position;
        go.GetComponent<SlimeController>().direction = slimeMovementDirection;
    }
}
