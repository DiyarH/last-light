using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInstanceController : MonoBehaviour
{
    public Sprite[] sprites;
    public Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (bounds != null)
        {
            if (transform.position.x >= bounds.spawnRightX + 0.1)
                transform.position = new Vector3(bounds.spawnLeftX + 0.5f, transform.position.y, transform.position.z);
            if (transform.position.x <= bounds.spawnLeftX - 0.1)
                transform.position = new Vector3(bounds.spawnRightX - 0.5f, transform.position.y, transform.position.z);
            if (transform.position.y >= bounds.spawnTopY + 0.1)
                transform.position = new Vector3(transform.position.x, bounds.spawnBottomY + 0.5f, transform.position.z);
            if (transform.position.y <= bounds.spawnBottomY - 0.1)
                transform.position = new Vector3(transform.position.x, bounds.spawnTopY - 0.5f, transform.position.z);
        }
    }
}
