using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardManager : MonoBehaviour
{


    [SerializeField]
    public string beingTyped;
    public int maxEntryLength = 9;
    public GameObject gameMenuUI, keyboard, createRoomButton, joinRoomButton, infoField;
    private string currentEntry =""; 
    public Text textDisplay, inputField;
    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        //myButton.onClick.AddListener(onCreateRoom);
        textDisplay.text = currentEntry;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void onCreateRoom()
    {
        Debug.Log("create");
        if (!keyboard.activeInHierarchy)
            {
                keyboard.SetActive(true);
            }
    }

    public void onLetterSelect(string thisButton)
    {

        int currentEntryLength = currentEntry.Length;



        if (currentEntryLength == 0 && thisButton != "back")
        {
            currentEntry = thisButton;
            updateInput(currentEntry);
        } 
        else if (thisButton == "back")
        {
            if (currentEntryLength == 0) { return; }
            else if (currentEntryLength == 1)
            {
                currentEntry = "";
                updateInput(currentEntry);
                return;
            }

            currentEntry = currentEntry.Substring(0, currentEntryLength - 1);
            updateInput(currentEntry);
            return;
        }

        else if (currentEntryLength >= maxEntryLength) { return; }
        else
        {
            currentEntry = currentEntry + thisButton;
        }
        updateInput(currentEntry);
    }

    public void onEnterSelect(string thisButton)
    {
        Debug.Log(thisButton);
        currentEntry = currentEntry + thisButton;
    }

    public void updateInput(string text)
    {
        textDisplay.text = text;
    }
}
