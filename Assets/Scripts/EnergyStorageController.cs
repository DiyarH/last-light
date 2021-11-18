using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AsteroidInstanceController;

public class EnergyStorageController : MonoBehaviour
{
    public EventManager eventManager;
    public float power = 90.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (power <= 0)
        {
            eventManager.OnGameLost.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            var size = collision.gameObject.GetComponent<AsteroidInstanceController>().size;
            switch (size)
            {
                case AsteroidSize.Big:
                    power -= 20;
                    break;
                case AsteroidSize.Medium:
                    power -= 15;
                    break;
                case AsteroidSize.Small:
                    power -= 10;
                    break;
                case AsteroidSize.Tiny:
                    power -= 5;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}
