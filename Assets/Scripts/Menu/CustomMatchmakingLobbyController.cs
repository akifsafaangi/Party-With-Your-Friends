using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomMatchmakingLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject lobbyConnectButton; // button for joining a lobby
    [SerializeField]
    private GameObject lobbyPanel; //button displaying panel lobby
    [SerializeField]
    private GameObject mainPanel; 
    [SerializeField]
    private TMP_InputField playerNameInput;

    private string roomName;
    private int roomSize;

    private List<RoomInfo> roomListings; // List of current rooms
    [SerializeField]
    private Transform roomsContainer; // container for holding all the the room listings
    [SerializeField]
    private GameObject roomListingPrefab; // prefab for displayer each room in the lobby


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true; // makes it so whatever scene the master client has
        lobbyConnectButton.SetActive(true);
        roomListings = new List<RoomInfo>(); // initializing roomListing

        if (PlayerPrefs.HasKey("NickName"))
         {
             if (PlayerPrefs.GetString("NickName") == "")
             {
                 PhotonNetwork.NickName = "Player " + Random.Range(0, 1000);
             }
             else
             {
                 PhotonNetwork.NickName = PlayerPrefs.GetString("NickName"); // get saved player name
             }
         }
         else
         {
             PhotonNetwork.NickName = "Player " + Random.Range(0, 1000);
         }
         playerNameInput.text = PhotonNetwork.NickName; // update input field with player name
    }

    public void PlayerNameUpdate(string nameInput) // input function for player name.paired to player
    {
        PhotonNetwork.NickName = nameInput;
        PlayerPrefs.SetString("NickName", nameInput);
    }
    public void JoinLobbyOnClick()
    {
        lobbyPanel.SetActive(true);
        PhotonNetwork.JoinLobby(); // Tries to join a lobby
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int tempIndex;
        foreach (RoomInfo room in roomList) // loop through each room in room list
        {
            if (roomListings != null) // try to find existing room listing
            {
                tempIndex = roomListings.FindIndex(ByName(room.Name));
            }
            else
            {
                tempIndex = -1;
            }
            if (tempIndex != -1) // remove listing because it has been closed
            {
                roomListings.RemoveAt(tempIndex);
                Destroy(roomsContainer.GetChild(tempIndex).gameObject);
            }
            if (room.PlayerCount > 0) // add room listing because it's new
            {
                roomListings.Add(room);
                ListRoom(room);
            }
        }
    }


     static System.Predicate<RoomInfo> ByName(string name) // predicate function for each through room
    {
        return delegate (RoomInfo room)
        {
            return room.Name == name;
        };
    }

    void ListRoom(RoomInfo room) // displays new room listing for the current room
    {
        if (room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomsContainer);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
        }
    }

    public void OnRoomNameChanged(string nameIn) // input function for changing room name
    {
        roomName = nameIn;
    }
    public void OnRoomSizeChanged(string sizeIn)
    {
        roomSize = int.Parse(sizeIn);
    }

    public void CreateRoom()
    {
        Debug.Log("Creating a room");
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom(roomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a room,there must already be a room with this name");
    }

    public void MatchmakingCancel()
    {
        mainPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }
}
