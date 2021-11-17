using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserInstanceController : LaserInstanceController
{
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
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
