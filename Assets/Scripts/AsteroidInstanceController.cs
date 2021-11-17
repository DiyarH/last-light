using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInstanceController : MonoBehaviour
{
    public enum AsteroidSize { Big, Medium, Small, Tiny }
    public Sprite[] sprites;
    public Bounds bounds;
    public AsteroidSize size;
    public AsteroidInstanceController smallerPart;
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

    public void Kill()
    {
        int partsCount = 0;
        float partMinSpeed = 0;
        switch (size)
        {
            case AsteroidSize.Big:
                partsCount = 3;
                partMinSpeed = 0.3f;
                break;
            case AsteroidSize.Medium:
                partsCount = 2;
                partMinSpeed = 0.5f;
                break;
            case AsteroidSize.Small:
                partsCount = Random.Range(0, 2);
                partMinSpeed = 0.7f;
                break;
            case AsteroidSize.Tiny:
                partsCount = 0;
                break;
        }
        for (int i = 0; i < partsCount; ++i)
        {
            var part = Instantiate(smallerPart).gameObject;
            var partDirection = Random.insideUnitCircle.normalized;
            part.transform.position = transform.position + (Vector3)partDirection * 0.2f;
            part.GetComponent<Rigidbody2D>().velocity = partDirection * Random.Range(partMinSpeed, 0.8f);
            part.GetComponent<AsteroidInstanceController>().bounds = bounds;
        }
        Destroy(this.gameObject);
    }
}
