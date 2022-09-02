using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab;
    public Direction slimeMovementDirection;
    public float slimeSpawnRate;

    private float lastSpawnTime = Mathf.NegativeInfinity;

    private void Update()
    {
        if (Time.time > lastSpawnTime + 1.0f / slimeSpawnRate)
        {
            lastSpawnTime = Time.time;
            GameObject go = Instantiate(slimePrefab);
            go.transform.position = transform.position;
            go.GetComponent<SlimeController>().direction = slimeMovementDirection;
        }
    }
}
