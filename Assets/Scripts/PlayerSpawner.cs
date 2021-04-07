using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField]private GameObject playerPrefab = null;
    Player[] allPlayers = PhotonNetwork.PlayerList;
    [SerializeField]Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allPlayers.Length; i++)
        {
            photonView.RPC("RPCSpawnPlayer", allPlayers[i], spawnPoints[i].position, Quaternion.identity);
        }
    }

    [PunRPC]
    void RPCSpawnPlayer(Vector3 spawnPos,Quaternion spawnRot)
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, spawnRot,0);
    }
}