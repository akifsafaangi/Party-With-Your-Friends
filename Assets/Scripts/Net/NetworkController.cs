using Photon.Pun;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //photon server settings Conneet to photon master servers
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are connected to the " + PhotonNetwork.CloudRegion + " server!");
    }
}