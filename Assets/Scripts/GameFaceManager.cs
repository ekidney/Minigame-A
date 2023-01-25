using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFaceManager : MonoBehaviour
{

    public static GameFaceManager Instance;
    private newRoom _usersRoom;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

}
