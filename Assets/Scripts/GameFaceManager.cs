using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFaceManager : MonoBehaviour
{

    public static GameFaceManager Instance;
    private newRoom _usersRoom;
    public bool initializeMinigame, gameRunning;

    [HideInInspector]
    public int killCount, score;

    public Text scoreboard; 
    public string roomName;


    private string debugMessage;
    
    private float m_userExp = 0;
    private int m_points;


    public enum MiniGame {
        Shooting,
        Building
    };


    public MiniGame currentGame = MiniGame.Shooting;

    public float userExp 
    {
        get { return m_userExp; } 
        set { m_userExp = value; } 
    }

    public int points
    {
        get { return m_points; }
        set { m_points = value; }
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

        //***Begin multigame logic here
        //NewMiniGame(currentGame);

    }

    public void GameOver()
    {
        if (currentGame == MiniGame.Shooting)
        {
            killCount = 0;
            Shooting thisGame = GetComponent<Shooting>();
            thisGame.onGameOver();
        }
        
    }

    void NewMiniGame(MiniGame _currentGame)
    {
        string newMiniGameScript = _currentGame.ToString();
        gameObject.AddComponent(System.Type.GetType(newMiniGameScript));
    }

    public void AddPoints(int arg)
    {
        score += arg;
        scoreboard.text = score.ToString();

    }



}
