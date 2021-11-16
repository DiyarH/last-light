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
            int spawnZone = Random.Range(0, 4);
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
            asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            timeUntilNextSpawn += spawnInterval;
        }
    }
}
