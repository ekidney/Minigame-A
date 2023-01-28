using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTraces : PlayerObjects
{
    // The speed of the bullet
    public float speed = 20f;

    // The amount of time the bullet can exist before it is destroyed
    public float lifetime = 10f;

    public int damage = 1;


    // The direction the bullet is moving in
    private Vector3 direction;

    // Reference to the bullet's rigidbody component
    private Rigidbody rb;


    private void Start()
    {
        // Get the bullet's rigidbody component
        rb = GetComponent<Rigidbody>();

        // Set the bullet's direction
        direction = transform.forward;

        // Destroy the bullet after a set amount of time
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        Debug.Log("lifetiume "+lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        // Check if the bullet hit an object with a "Damageable" tag
        if ((collision.collider.CompareTag("Damageable")))
        {
            // Apply damage to the object
            collision.gameObject.GetComponent<Damageable>().ApplyDamage(damage);
        }


        // Destroy the bullet
        Destroy(gameObject);
    }


}
