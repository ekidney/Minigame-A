using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Minigame : MonoBehaviour
{
    public int playerCount;
    private float gameDuration;

    public enum GameThings { };

    [SerializeField]
    private float remainingTime;

    public virtual void OnWin() { }

    public virtual void OnLose() { }




}
