using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Target : Damageable
{
    // POLYMORPHISM
    public override void ApplyDamage(int damage)
    {
        // Destroy the object
        Destroy(gameObject);
    }
}
