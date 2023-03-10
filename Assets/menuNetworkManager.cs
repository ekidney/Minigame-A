using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Chiligames.MetaAvatarsPun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuNetworkManager : NetworkManager
{
    public Text infoText;
    public KeyboardManager thisKeyboardManager;
    




    private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
        }

    



    public override void ConnectToMaster()
    {
        PhotonNetwork.OfflineMode = false; //true would "fake" an online connection
        PhotonNetwork.NickName = "PlayerName"; //we can use a input to change this 
        PhotonNetwork.AutomaticallySyncScene = true; //To call PhotonNetwork.LoadLevel()
        PhotonNetwork.GameVersion = "v1"; //only people with the same game version can play together
        PhotonNetwork.UseRpcMonoBehaviourCache = true;

        //PhotonNetwork.ConnectToMaster(ip, port, appid); //manual connection
        PhotonNetwork.ConnectUsingSettings(); //automatic connection based on the config file
        Debug.Log("connecting using settings");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        infoText.text = "Connected!";
        Debug.Log("connected to master");
        ConnectToRoom();
    }

    public override void ConnectToRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions roomOptions = new RoomOptions();
        //Room max is set to 10, as there are 10 spawning point locations. Max Pun2 FREE amount of users in a room can be set to 20.
        roomOptions.MaxPlayers = 10;
        //The name of the room can be changed here, or randomized.
        string roomName = thisKeyboardManager.currentEntry;
        infoText.text = "CREATING " + roomName;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        infoText.text = "Joining room...";
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + " | RoomName: " + PhotonNetwork.CurrentRoom.Name + " Region: " + PhotonNetwork.CloudRegion);
        SceneManager.LoadScene(1);
    }

}
