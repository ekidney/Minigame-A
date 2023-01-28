using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFaceManager : MonoBehaviour
{

    public static GameFaceManager Instance;
    private newRoom _usersRoom;
    public bool initializeMinigame;



    private float m_userExp = 0;

    
    public float userExp 
    {
        get { return m_userExp; } // getter returns backing field
        set { m_userExp = value; } // setter uses backing field
    }

    private void Start()
    {
        

    }



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



}
