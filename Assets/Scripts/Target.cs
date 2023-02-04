using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : Damageable
{
    public float timeCounter;
    public float targetHeight = 1;
    public float distance = 1;
    public float spinMultiplier = 100f;
    public float speed = 1f;
    public int directionMultiplier;

    void Update()
    {

        timeCounter = timeCounter + (speed * Time.deltaTime); 
        
        float x = Mathf.Cos(directionMultiplier * timeCounter) * distance;
        float z = Mathf.Sin(directionMultiplier * timeCounter) * distance;
        float y = targetHeight;
        transform.position = new Vector3(x, y, z);
        transform.Rotate(0.0f, Time.deltaTime * spinMultiplier, 0.0f, Space.Self);
        
    }

}
