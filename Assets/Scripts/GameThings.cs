using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameThings : MonoBehaviour
{
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

}