using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Direction movementDirection;

    public void QueueSpawn(GameObject prefab)
    {
        spawnQueue.Enqueue(prefab);
    }

    private float spawnCooldown = 0.0f;

    private Queue<GameObject> spawnQueue = new Queue<GameObject>();

    private SpawnController enemySpawnController;

    private void Start()
    {
        enemySpawnController = GetComponentInParent<SpawnController>();
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
        IMoving m = go.GetComponent<IMoving>();
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.velocity = DirectionUtil.ToVector(movementDirection) * m.InitialSpeed;
    }
}
