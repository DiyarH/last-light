using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public float spawnTopY, spawnBottomY, spawnRightX, spawnLeftX;
    // Start is called before the first frame update
    void Start()
    {
        var cam = Camera.main;
        spawnTopY = cam.orthographicSize + 1;
        spawnRightX = cam.orthographicSize * cam.aspect + 1;
        spawnBottomY = -spawnTopY;
        spawnLeftX = -spawnRightX;
    }
}
