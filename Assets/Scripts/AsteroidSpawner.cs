using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidInstanceController[] asteroids;
    public float spawnInterval;
    private float timeUntilNextSpawn;
    private Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        bounds = gameObject.GetComponent<Bounds>();
        timeUntilNextSpawn = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0.0f)
        {
            var asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Length)].gameObject);
            asteroid.GetComponent<AsteroidInstanceController>().bounds = bounds;
            int spawnZone = 0;
            //int spawnZone = Random.Range(0, 4);
            Vector3 position = Vector3.zero;
            if (spawnZone / 2 == 0) // Top & Bottom
                position.x = Random.Range(bounds.spawnLeftX, bounds.spawnRightX);
            else if (spawnZone == 2) // Right
                position.x = bounds.spawnRightX;
            else // Left
                position.x = bounds.spawnLeftX;
            if (spawnZone / 2 == 1) // Right & Left
                position.y = Random.Range(bounds.spawnBottomY, bounds.spawnTopY);
            else if (spawnZone == 0) // Top
                position.y = bounds.spawnTopY;
            else // Bottom
                position.y = bounds.spawnBottomY;
            asteroid.transform.position = position;
            Vector2 target = Vector2.zero;
            if (spawnZone / 2 == 0) // Top & Bottom
                target.x = Random.Range(bounds.spawnLeftX, bounds.spawnRightX);
            else if (spawnZone == 2) // Right
                target.x = bounds.spawnLeftX;
            else // Left
                target.x = bounds.spawnRightX;
            if (spawnZone / 2 == 1) // Right & Left
                target.y = Random.Range(bounds.spawnBottomY, bounds.spawnTopY);
            else if (spawnZone == 0) // Top
                target.y = bounds.spawnBottomY;
            else // Bottom
                target.y = bounds.spawnTopY;
            var targetDistance = target - (Vector2)asteroid.transform.position;
            asteroid.GetComponent<Rigidbody2D>().velocity = targetDistance.normalized * Random.Range(0.3f, 0.8f);
            timeUntilNextSpawn += spawnInterval;
        }
    }
}
