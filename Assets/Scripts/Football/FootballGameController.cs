using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class FootballGameController : MonoBehaviourPun
{
    private bool MatchActive;
    public float LeftBallCount = 0f;
    //EndingMatch
    public TMP_Text winnerText;
    [SerializeField] GameObject winnerPanel;
    float winnerTimer = 6f;

    //Timer
    public TMP_Text timerText;
    public int matchTime = 20;
    private float tenSeconds = 10;
    private float Timer = 1;
    private int tenSecondsSecond = 10;


    //PlayerScores
    private int Score = 3;
    private int Team1Score;
    private int Team2Score;
    private int Team3Score;
    private int Team4Score;
    public TMP_Text Team1Text;
    public TMP_Text Team2Text;
    public TMP_Text Team3Text;
    public TMP_Text Team4Text;

    //DestroyPlayers
    [SerializeField]int[] GameObjectOwnerID;

    Player[] destroyPlayer = PhotonNetwork.PlayerList;

    // Start is called before the first frame update
    void Start()
    {
        MatchActive = true;
        Team1Score = Score;
        Team2Score = Score;
        Team3Score = Score;
        Team4Score = Score;
        for (int i = 0; i < destroyPlayer.Length; i++)
        {
           // GameObjectOwnerID[i] = destroyPlayer[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= matchTime - 10 && Timer <= matchTime)
        {
            timerText.text = tenSecondsSecond.ToString();
            tenSeconds -= Time.deltaTime;
            tenSecondsSecond = Mathf.RoundToInt(tenSeconds);
        }
        else if (Timer > matchTime)
        {
            MatchActive = false;
        }

        if (!MatchActive)
        {
            winnerPanel.SetActive(true);
            winnerText.text = "";
            winnerTimer -= Time.deltaTime;
            if (winnerTimer <= 0)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.AutomaticallySyncScene = true;
                    PhotonNetwork.LoadLevel(1);
                }
            }
        }
        DestroyingPlayers();
    }

    private void DestroyingPlayers()
    {
        if (Team1Score == 0)
        {
            photonView.RPC("NetworkDestroy", RpcTarget.All, 2);
        }
        if (Team2Score == 0)
        {
            photonView.RPC("NetworkDestroy", RpcTarget.All, 3);
        }
        if (Team3Score == 0)
        {
            photonView.RPC("NetworkDestroy", RpcTarget.All, 4);
        }
        if (Team4Score == 0)
        {
            photonView.RPC("NetworkDestroy", RpcTarget.All, 5);
        }
    }

    public void Team1()
     {
        if (MatchActive)
        {
            Team1Score--;
            Team1Text.text = Team1Score.ToString();
            LeftBallCount++;
        }
     }
     public void Team2()
     {
        if (MatchActive)
        {
            Team2Score--;
            Team2Text.text = Team2Score.ToString();
            LeftBallCount++;
        }
     }
     public void Team3()
     {
        if (MatchActive)
        {
            Team3Score--;
            Team3Text.text = Team3Score.ToString();
            LeftBallCount++;
        }
     }
     public void Team4()
     {
        if (MatchActive)
        {
            Team4Score--;
            Team4Text.text = Team4Score.ToString();
            LeftBallCount++;
        }
     }

    [PunRPC]
    void NetworkDestroy(int viewID)
    {
      //  PhotonNetwork.Destroy(PhotonNetwork.PlayerList[viewID].UserId.);
    }
}
