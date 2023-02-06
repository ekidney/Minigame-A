using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFaceManager : MonoBehaviour
{

    [SerializeField] private List<PlayerData> playerData = new List<PlayerData>();

    [HideInInspector]
    public int killCount, score;
    public Text scoreboard; 
    public string roomName;
    public static GameFaceManager Instance;
    public bool initializeMinigame, gameRunning;

    private string debugMessage;
    private float m_userExp = 0;
    private int m_points;
    private newRoom _usersRoom;


    // More games to add here
    // Need to implement game class being added/destroyed by this manager 
    // is there a way to do it thats not a bunch of if this enum then this script?
    public enum MiniGame {
        Shooting,
        Building

    };


    public MiniGame currentGame = MiniGame.Shooting;


    // Might put some logic into user experience points setter
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

        //Begin populating player data here?
        playerData.Add(new PlayerData(0, true, 0, 0));
    }

    private void Start()
    {
        
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
