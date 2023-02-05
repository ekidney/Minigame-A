using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Minigame : MonoBehaviour
{
    public int playerCount;
    private float gameDuration;
    private string debugmessage;
    public enum GameThings { };
    public Text debugText;

    [SerializeField]
    private float remainingTime;


    public virtual void OnWin() { }

    public virtual void OnLose() { }

    public bool GetRandomBool()
    {
        int randomNumber = Random.Range(0, 100);
        return (randomNumber % 2 == 0) ? true : false;
    }




}
