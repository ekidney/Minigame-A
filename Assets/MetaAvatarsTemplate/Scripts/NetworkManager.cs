using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Collections;
//
//This script connects to PHOTON servers and creates a room if there is none, then automatically joins
//
namespace Chiligames.MetaAvatarsPun
{
    

    public class NetworkManager : MonoBehaviourPunCallbacks
    {
        public static NetworkManager instance;
        public string thisRoomName ="Dev Room";
        

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

        private void Start()
        {
            
            if (GameFaceManager.Instance.roomName != string.Empty)
            {
                thisRoomName = GameFaceManager.Instance.roomName;

            }
                 ConnectToMaster();

             

        }

        public virtual void ConnectToMaster()
        {
            Debug.Log("connecting to master...");
            PhotonNetwork.OfflineMode = false; //true would "fake" an online connection
            PhotonNetwork.NickName = "PlayerName"; //we can use a input to change this 
            PhotonNetwork.AutomaticallySyncScene = true; //To call PhotonNetwork.LoadLevel()
            PhotonNetwork.GameVersion = "v1"; //only people with the same game version can play together
            PhotonNetwork.UseRpcMonoBehaviourCache = true;

            //PhotonNetwork.ConnectToMaster(ip, port, appid); //manual connection
            PhotonNetwork.ConnectUsingSettings(); //automatic connection based on the config file
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            Debug.Log(cause);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("Connected to master!");
            ConnectToRoom();
        }

        public virtual void ConnectToRoom()
        {
            if (!PhotonNetwork.IsConnected)
                return;

            RoomOptions roomOptions = new RoomOptions();
            //Room max is set to 10, as there are 10 spawning point locations. Max Pun2 FREE amount of users in a room can be set to 20.
            roomOptions.MaxPlayers = 10;
            //The name of the room can be changed here, or randomized.
            
            PhotonNetwork.JoinOrCreateRoom(thisRoomName, roomOptions, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
           
                base.OnJoinedRoom();

            //load arena if in menu
            if (SceneManager.GetActiveScene().name == "Launcher")
            {
                SceneManager.LoadScene(1);
            }

            Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + " | RoomName: " + PhotonNetwork.CurrentRoom.Name + " Region: " + PhotonNetwork.CloudRegion);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            ConnectToRoom();
        }
    }
}