﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AsteroidInstanceController;

public class PlayerController : MonoBehaviour
{
    public EventManager eventManager;
    private Rigidbody2D rigidbody;
    [Range(0.0f, 10.0f)]
    public float acceleration;
    [Range(0.0f, 100.0f)]
    public float rotationSpeed;
    public float terminalVelocity;
    public PlayerLaserInstanceController laser;
    public float movementPowerUsage = 0.2f;
    public float rotationPowerUsage = 0.1f;
    public float power = 100.0f;
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
            power -= rotationPowerUsage * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.rotation -= rotationSpeed * Time.deltaTime;
            power -= rotationPowerUsage * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity += forward * acceleration * Time.deltaTime;
            power -= movementPowerUsage * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(laser).gameObject;
            bullet.transform.position = transform.position + (Vector3)forward * 0.2f;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = forward * 15;
        }
        rigidbody.drag = (float)Math.Exp(rigidbody.velocity.magnitude - terminalVelocity);
        if (power <= 0)
        {
            GameOver();
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
                    power -= 30;
                    break;
                case AsteroidSize.Medium:
                    power -= 25;
                    break;
                case AsteroidSize.Small:
                    power -= 20;
                    break;
                case AsteroidSize.Tiny:
                    power -= 15;
                    break;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            power += collision.gameObject.GetComponent<PowerupInstanceController>().powerRestoreAmount;
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        eventManager.OnGameLost.Invoke();
        gameObject.SetActive(false);
    }
}
