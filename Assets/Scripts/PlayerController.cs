using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [Range(0.0f, 10.0f)]
    public float acceleration;
    [Range(0.0f, 100.0f)]
    public float rotationSpeed;
    public float terminalVelocity;
    public PlayerLaserInstanceController laser;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 forward = transform.up;
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.rotation += rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.rotation -= rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity += forward * acceleration * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(laser).gameObject;
            bullet.transform.position = transform.position + (Vector3)forward * 0.2f;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = forward * 15;
        }
        rigidbody.drag = (float)Math.Exp(rigidbody.velocity.magnitude - terminalVelocity);
    }
}
