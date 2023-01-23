using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardManager : MonoBehaviour
{


    [SerializeField]
    public string beingTyped;

    public GameObject gameMenuUI, keyboard, createRoomButton, joinRoomButton, infoField;
    private string inputLetter; 
    public Text textDisplay, inputField;
    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(onCreateRoom);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddLetter()
    {
        beingTyped = beingTyped + inputLetter;

    }

    public void onCreateRoom()
    {
        Debug.Log("create");
        if (!keyboard.activeInHierarchy)
            {
                keyboard.SetActive(true);
            }
    }

    private void onJoinRoom()
    {

    }
}
