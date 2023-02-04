using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : GameThings
{
    // The maximum health of the object
    public int maxHealth = 0;


    // The current health of the object
    public int health;

    // The sound effect that plays when the object takes damage
    public AudioClip damageSound;

    // The sound effect that plays when the object is destroyed
    public AudioClip deathSound;

    // The audio source component
    public AudioSource audioSource;




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

        

        // Check if the object's health is below zero
        if (health <= 0)
        {
            

            // Destroy the object
            killObject();

        }

    }

    public void PlaySound(AudioClip clip, AudioSource audiosource)
    {
        if (clip == null || audiosource == null)
        {
            Debug.Log("missing audio or clip");
        }
        if (!audioSource.isPlaying)
        {
            
            
            audioSource.clip = clip;
            audiosource.Play();
        }
        
        return;

    }




    public virtual void killObject()
    {
        
        // Play the death sound
        MeshRenderer thisMesh = GetComponent<MeshRenderer>();
        thisMesh.enabled = false; 
        PlaySound(deathSound, audioSource);
        //Destroy(gameObject, 5f);
    }
}
