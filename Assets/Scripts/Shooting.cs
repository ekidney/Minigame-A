using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : Minigame
{


    //public GameObject prefab;

    public int targetCount = 1, targetIncreaseRate = 1;
    
    public float minSpeed = 0.3f, maxSpeed = 7f;

    // TODO Needs to be converted to a debugger method 
    public Text showing;

    private AudioSource tableAudio;
    private Animator tableAnimator;
    private float distanceFromcenter;
    int directionMultiplier;
    [SerializeField]
    GameObject gameTable;
    public AudioClip gameFace;

    void Start()
    {
        showing.text = "starting...";
        //SpawnTargets(targetCount);
        
    }

    void Awake()
    {
        gameTable = GameObject.Find("Table");
        tableAnimator = gameTable.GetComponent<Animator>();
        tableAudio = gameTable.GetComponent<AudioSource>();
        showing.text = "waking...";
        InitGame(targetCount);
    }

    void Update()
    {
        
    }

    void InitGame(int _targetCount)
    {
        GameFaceManager.Instance.killCount = 0;
        
        SpawnTargets(_targetCount);
        GameFaceManager.Instance.gameRunning = true;
    }


    public void SpawnTargets(int numTargets)
    {
        
        for (int i = 0; i < numTargets + 1; i++)
        {
            //Spin targets in a circle around the center
            
            Debug.LogError("number to kill: " + GameFaceManager.Instance.killCount);
            Debug.LogError("creating target number" + i + " : " + gameObject.name);
            GameFaceManager.Instance.killCount += 1;
            float randomDistance = Random.Range(1f, 6f);
            float randomHeight = Random.Range(0.18f, 2.6f);
            bool newDirection = GetRandomBool();
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            CreateTarget(randomSpeed, randomDistance, Random.Range(50, 100), randomHeight, newDirection);

        }
    }

    public void CreateTarget(float speed, float distance, float spin, float height, bool direction)
    {
        
        GameObject prefab = Resources.Load("TargetA") as GameObject;
        if (prefab == null)
        {
            showing.text = "Target Prefab Not Found";
        }

        GameObject target = Instantiate(prefab) as GameObject;

        Target _newTarget = target.GetComponent<Target>();
        if (!direction) { directionMultiplier = 1; } else { directionMultiplier = -1; }
        _newTarget.distance = distance;
        _newTarget.spinMultiplier = spin;
        _newTarget.directionMultiplier = directionMultiplier;
        _newTarget.speed = speed;
        _newTarget.targetHeight = height;

    }

    public void onGameOver()
    {
        showing.text = "new wave...";
        if (tableAnimator != null)
        {
            
            tableAnimator.Play("GameFace Enter and Exit");

            tableAudio.PlayOneShot(gameFace);
            targetCount = targetCount + targetIncreaseRate;
            Invoke("restartGame",10f);
        }
    }

    void restartGame()
    {
        
        InitGame(targetCount);
    }


}
