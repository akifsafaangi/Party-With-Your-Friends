using TMPro;
using UnityEngine;
using Photon.Pun;

public class WaitingRoomController : MonoBehaviour
{
    PhotonView myPV;
    float timeToStart = 5f;
    float timerToStart;
    bool readyToStart = false;

    [SerializeField] GameObject startButton;
    [SerializeField] TMP_Text countDownDisplay;

    [SerializeField] int randomLevel;

    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        timerToStart = timeToStart;
    }

    // Update is called once per frame
    void Update()
    {
        startButton.SetActive(PhotonNetwork.IsMasterClient);
            if (readyToStart == true)
            {
                timerToStart -= Time.deltaTime;
                countDownDisplay.text = ((int)timerToStart).ToString();
            }
            else
            {
                timerToStart = timeToStart;
                countDownDisplay.text = "";
            }
        if (PhotonNetwork.IsMasterClient)
        {
            if (timerToStart <= 0)
            {
                timerToStart = 100;
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.LoadLevel(randomLevel);
            }
        }
    }

    public void Play()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            myPV.RPC("RPC_Play",RpcTarget.All);
        }
    }

    [PunRPC]
    void RPC_Play()
    {
        readyToStart = true;
    }
}
