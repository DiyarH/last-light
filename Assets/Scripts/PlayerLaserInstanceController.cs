using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserInstanceController : LaserInstanceController
{
    public PlayerController player;
    public EventManager eventManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            player.score += collision.gameObject.GetComponent<AsteroidInstanceController>().scoreOnDestruction;
            eventManager.OnAsteroidDestroyed.Invoke();
            collision.gameObject.GetComponent<AsteroidInstanceController>().Kill();
            Destroy(this.gameObject);
        }
    }
}
