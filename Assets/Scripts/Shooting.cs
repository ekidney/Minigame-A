using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Minigame
{
    // Start is called before the first frame update

    public GameObject prefab;

    public int targetCount;
    int directionMultiplier;
    public float minSpeed = 0.5f, maxSpeed = 1f;


    private float distanceFromcenter;

    void Start()
    {
        SpawnTargets(targetCount);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTargets(int numTargets)
    {
        for (int i = 0; i < numTargets + 1; i++)
        {
            float randomDistance = Random.Range(1f, 6f);
            float randomHeight = Random.Range(0.18f, 2.6f);
            bool newDirection = GetRandomBool();
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            CreateTarget(randomSpeed, randomDistance, Random.Range(50, 100), randomHeight, newDirection);

        }
    }

    public void CreateTarget(float speed, float distance, float spin, float height, bool direction)
    {
        //Debug.LogError("speed "+speed+" distance " + distance + " spin " + spin + " height " + height + " direction " + direction);
        GameObject target = Instantiate(prefab) as GameObject;
        Target _newTarget = target.GetComponent<Target>();
        
        if (!direction) { directionMultiplier = 1; } else { directionMultiplier = -1; }
        _newTarget.distance = distance;
        _newTarget.spinMultiplier = spin;
        _newTarget.directionMultiplier = directionMultiplier;
        _newTarget.speed = speed;
        _newTarget.targetHeight = height;

    }



}
