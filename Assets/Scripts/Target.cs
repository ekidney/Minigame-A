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
    private bool hasRun;
    private void Awake()
    {
        
    }

    void Update()
    {

        timeCounter = timeCounter + (speed * Time.deltaTime); 
        
        float x = Mathf.Cos(directionMultiplier * timeCounter) * distance;
        float z = Mathf.Sin(directionMultiplier * timeCounter) * distance;
        float y = targetHeight;
        transform.position = new Vector3(x, y, z);
        transform.Rotate(0.0f, Time.deltaTime * spinMultiplier, 0.0f, Space.Self);
        
    }


    public override void killObject()
    {
        if (!hasRun)
        {
            hasRun = true;
            MeshRenderer thisMesh = GetComponent<MeshRenderer>();
            thisMesh.enabled = false;
            PlaySound(deathSound, audioSource);
            GameFaceManager.Instance.AddPoints(10);
            GameFaceManager.Instance.killCount -= 1;
            Debug.LogError("killed: " + gameObject.name +" // killcount: " + GameFaceManager.Instance.killCount);
            if (GameFaceManager.Instance.killCount == 0)
            {
                GameFaceManager.Instance.GameOver();
            }
            Destroy(gameObject, 3f);
        }
    }

}



