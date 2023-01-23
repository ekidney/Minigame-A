using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : GameThings
{
    // The maximum health of the object
    public int maxHealth = 100;

    // The current health of the object
    public int health;

    // The sound effect that plays when the object takes damage
    public AudioClip damageSound;

    // The sound effect that plays when the object is destroyed
    public AudioClip deathSound;

    // The audio source component
    private AudioSource audioSource;

    private void Start()
    {
        // Set the object's initial health
        health = maxHealth;

        // Get the audio source component
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void ApplyDamage(int damage)
    {
        // Decrement the object's health
        health -= damage;

        // Play the damage sound
        PlaySound(damageSound);

        // Check if the object's health is below zero
        if (health <= 0)
        {
            // Play the death sound
            PlaySound(deathSound);

            // Destroy the object
            Destroy(gameObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
