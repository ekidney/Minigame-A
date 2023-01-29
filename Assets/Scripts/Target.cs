using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Target : Damageable
{
    public float experiencePoints; 
    // POLYMORPHISM
    public override void killObject()
    {
        PlaySound(deathSound);
        GiveExperience(experiencePoints);
        Destroy(gameObject);


    }


}
