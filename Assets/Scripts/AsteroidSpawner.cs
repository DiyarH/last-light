using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidInstanceController[] asteroids;
    public float spawnInterval;
    private float timeUntilNextSpawn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0.0f)
        {
            var asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Length)].gameObject);
            asteroid.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
            asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            timeUntilNextSpawn += spawnInterval;
        }
    }
}
