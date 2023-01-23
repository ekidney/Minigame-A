using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : PlayerObjects
{
    // The prefab of the bullet that the gun fires
    public GameObject bulletPrefab;

    // The point at which the bullet is spawned
    public Transform spawnPoint;

    // The rate at which the gun can fire
    public float fireRate = 0.1f;

    public int ammo = 30;

    // The audio source component
    private AudioSource audioSource;
    public AudioClip fireSound, dryFireSound;
    private float nextFireTime;

    private void Start()
    {
        // Get the audio source component
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (ammo > 0 && Time.time >= nextFireTime)
            {
                // Fire the gun
                Fire();
                nextFireTime = Time.time + 1f / fireRate;
            }
            else if (ammo <= 0)
            {
                // Play the dry fire sound
                PlaySound(dryFireSound);
            }
        }
    }

    private void Fire()
    {
        // Spawn the bullet
        GameObject _projectile = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        // Add force to the projectile? more complex shooter maybe
        // bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * bulletForce, ForceMode.Impulse);

        // Play the fire sound
        PlaySound(fireSound);

        // Decrement the ammo count
        ammo--;
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
