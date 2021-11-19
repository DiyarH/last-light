using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AsteroidInstanceController;

public class PlayerController : MonoBehaviour
{
    public Bounds bounds;
    public EventManager eventManager;
    public GameObject fire;
    private Rigidbody2D rigidbody;
    public AudioSource laserSound;
    public AudioSource powerupSound;
    public AudioSource loseSound;
    public AudioSource asteroidExplosionSound;
    public AudioSource engineSound;
    public AudioSource spaceshipCollisionSound;
    [Range(0.0f, 10.0f)]
    public float acceleration;
    [Range(0.0f, 360.0f)]
    public float rotationSpeed;
    public float terminalVelocity;
    public PlayerLaserInstanceController laser;
    public float movementPowerUsage = 0.2f;
    public float rotationPowerUsage = 0.1f;
    public float laserPowerUsage = 0.5f;
    public float power = 100.0f;
    public int score = 0;
    public float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool moving = false;
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            Win();
        }
        Vector2 forward = transform.up;
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.rotation += rotationSpeed * Time.deltaTime;
            power -= rotationPowerUsage * Time.deltaTime;
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.rotation -= rotationSpeed * Time.deltaTime;
            power -= rotationPowerUsage * Time.deltaTime;
            moving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity += forward * acceleration * Time.deltaTime;
            power -= movementPowerUsage * Time.deltaTime;
            moving = true;
        }
        if (moving && !engineSound.isPlaying)
        {
            engineSound.Play();
        }
        else if (!moving && engineSound.isPlaying)
        {
            engineSound.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var laserInstance = Instantiate(laser).gameObject;
            laserInstance.transform.position = transform.position + (Vector3)forward * 0.2f;
            laserInstance.transform.rotation = transform.rotation;
            laserInstance.GetComponent<Rigidbody2D>().velocity = forward * 15;
            laserInstance.GetComponent<PlayerLaserInstanceController>().player = this;
            laserInstance.GetComponent<PlayerLaserInstanceController>().eventManager = eventManager;
            laserInstance.GetComponent<PlayerLaserInstanceController>().bounds = bounds;
            laserInstance.GetComponent<PlayerLaserInstanceController>().aseroidExplosionSound = asteroidExplosionSound;
            power -= laserPowerUsage;
            laserSound.Play();
        }
        rigidbody.drag = (float)Math.Exp(rigidbody.velocity.magnitude - terminalVelocity);
        if (power <= 0)
        {
            GameOver();
        }
        if (bounds != null)
        {
            if (transform.position.x >= bounds.spawnRightX - 0.7)
                transform.position = new Vector3(bounds.spawnLeftX + 0.72f, transform.position.y, transform.position.z);
            if (transform.position.x <= bounds.spawnLeftX + 0.7)
                transform.position = new Vector3(bounds.spawnRightX - 0.72f, transform.position.y, transform.position.z);
            if (transform.position.y >= bounds.spawnTopY - 0.7)
                transform.position = new Vector3(transform.position.x, bounds.spawnBottomY + 0.72f, transform.position.z);
            if (transform.position.y <= bounds.spawnBottomY + 0.7)
                transform.position = new Vector3(transform.position.x, bounds.spawnTopY - 0.72f, transform.position.z);
        }
        fire.SetActive(moving);
    }

    private void Win()
    {
        eventManager.OnGameWon.Invoke();
        gameObject.SetActive(false);
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
            if (power < 0)
                power = 0;
            spaceshipCollisionSound.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            power += collision.gameObject.GetComponent<PowerupInstanceController>().powerRestoreAmount;
            if (power > 100)
                power = 100;
            Destroy(collision.gameObject);
            powerupSound.Play();
        }
    }

    void GameOver()
    {
        loseSound.Play();
        eventManager.OnGameLost.Invoke();
        gameObject.SetActive(false);
    }
}
