using UnityEngine;
using TMPro;

public class VolleyballGameController : MonoBehaviour
{
    public TMP_Text team1Text;
    public TMP_Text team2Text;
    public TMP_Text timerText;
    public int matchTime = 20;
    private float tenSeconds = 10;
    private float Timer = 1;
    private int tenSecondsSecond = 10;
    private bool MatchActive;
    public float LeftBallCount = 0f;

    //PlayerScores
    private int team1Score = 0;
    private int team2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        MatchActive = true;
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
    }

     public void Team1()
     {
       if (MatchActive)
       {
          team1Score++;
          team1Text.text = team1Score.ToString();
          LeftBallCount++;
       }
     }
     public void Team2()
     {
       if (MatchActive)
       {
          team2Score++;
          team2Text.text = team2Score.ToString();
          LeftBallCount++;
       }
     }
}
