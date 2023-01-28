using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Target : Damageable
{
    public float experienceWorth; 
    // POLYMORPHISM
    public override void killObject()
    {
        PlaySound(deathSound);
        GiveExperience(experienceWorth);
        Destroy(gameObject);


    }


}
