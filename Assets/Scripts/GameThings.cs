using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameThings : MonoBehaviour
{

    public GameObject singletonInstance;
    private GameFaceManager gameFaceManager;

    private void Start()
    {
        gameFaceManager = GetComponent<GameFaceManager>();

    }
    public virtual void Spawn(GameObject prefabToSpawn, Vector3 position, Quaternion rotation)

    {

        Instantiate(prefabToSpawn, position, rotation);


    }

    public virtual void Destroy()

    {
        Destroy(this);

    }


    protected virtual void DoTransition()
    {
        
    }

    public void GiveExperience(float expAmount)
    {
        float temp = gameFaceManager.userExp;
        temp = temp + expAmount;
        gameFaceManager.userExp = temp;


    }


}