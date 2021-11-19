using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserInstanceController : LaserInstanceController
{
    public PlayerController player;
    public EventManager eventManager;
    public Bounds bounds;
    public AudioSource aseroidExplosionSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bounds != null)
        {
            if ((transform.position.x >= bounds.spawnRightX)
            || (transform.position.x <= bounds.spawnLeftX)
            || (transform.position.y >= bounds.spawnTopY)
            || (transform.position.y <= bounds.spawnBottomY))
                Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            player.score += collision.gameObject.GetComponent<AsteroidInstanceController>().scoreOnDestruction;
            eventManager.OnAsteroidDestroyed.Invoke();
            collision.gameObject.GetComponent<AsteroidInstanceController>().Kill();
            aseroidExplosionSound.Play();
            Destroy(this.gameObject);
        }
    }
}
